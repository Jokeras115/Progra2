using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Bools")]
    [Space]
    [SerializeField] bool gameHasEnded = false;
    [SerializeField] bool hasWinGame = false;
    [SerializeField] Image bulletImage;
    [SerializeField] Text bulletText;
    [SerializeField] Image mediPackImage;
    [SerializeField] PlayerController player;
    [SerializeField] NameMenu nameMenu;
    public int node1ID;
    public int node2ID;
    public List<int> medikitsID = new List<int>();
    public string playerName;
    public int playerScore;
    #endregion

    #region Singleton
    static GameManager _instance;
    public static GameManager managerInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion

    #region Functions
    private void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void Start()
    {
    }
    public void AskPlayerName()
    {
        //if (nameMenu == null)
        //{
        //    nameMenu = GameObject.Find("AskNamePannel")?.GetComponent<NameMenu>();
        //}
        nameMenu = GameObject.Find("AskNamePannel")?.GetComponent<NameMenu>();
        nameMenu.GetComponent<Canvas>().enabled = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level02")
            SceneManager.LoadScene("HighScore");
        else
            SceneManager.LoadScene("Level02");

        bulletImage = GameObject.Find("Ammo")?.GetComponent<Image>();
        bulletText = GameObject.Find("Magazine")?.GetComponent<Text>();
        mediPackImage = GameObject.Find("MediPack")?.GetComponent<Image>();
        player = GameObject.Find("Player")?.GetComponent<PlayerController>();
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level01" || SceneManager.GetActiveScene().name == "Level02")
        {
            UpdatePlayerAmmo();
            UpdatePlayerMediPacks();
        }
    }

    public void Fall()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        if (hasWinGame == false)
        {
            hasWinGame = true;
            WinMenu();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            EndMenu();
        }
    }

    public void UpdatePlayerAmmo()
    {
        if (player == null || bulletImage == null || bulletText == null || mediPackImage == null)
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            bulletImage = GameObject.Find("Ammo").GetComponent<Image>();
            bulletText = GameObject.Find("Magazine").GetComponent<Text>();
            mediPackImage = GameObject.Find("MediPack").GetComponent<Image>();
        }
        switch (player.ammoType)
        {
            case BulletTypes.Basic:
                bulletImage.color = new Color(255, 255, 0, 255);
                bulletText.text = "\u221E";
                break;
            case BulletTypes.Blue:
                bulletImage.color = new Color(0, 0, 255, 255);
                bulletText.text = player.magazine.ToString();
                break;
            case BulletTypes.Green:
                bulletImage.color = new Color(0, 255, 0, 255);
                bulletText.text = player.magazine.ToString();
                break;
            case BulletTypes.Red:
                bulletImage.color = new Color(255, 0, 0, 255);
                bulletText.text = player.magazine.ToString();
                break;
            default:
                break;
        }
    }

    public void UpdatePlayerMediPacks()
    {
        if (player == null || bulletImage == null || bulletText == null || mediPackImage == null)
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            bulletImage = GameObject.Find("Ammo").GetComponent<Image>();
            bulletText = GameObject.Find("Magazine").GetComponent<Text>();
            mediPackImage = GameObject.Find("MediPack").GetComponent<Image>();
        }
        switch (player.mediPackType)
        {
            case MediPackTypes.White:
                mediPackImage.color = new Color(255, 255, 255, 255);
                break;
            case MediPackTypes.Blue:
                mediPackImage.color = new Color(0, 0, 255, 255);
                break;
            case MediPackTypes.Green:
                mediPackImage.color = new Color(0, 255, 0, 255);
                break;
            case MediPackTypes.Red:
                mediPackImage.color = new Color(255, 0, 0, 255);
                break;
            default:
                break;
        }
    }

    private void EndMenu()
    {
        SceneManager.LoadScene("LooseMenu");
    }

    private void WinMenu()
    {
        SceneManager.LoadScene("WinMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Is Quitting...");
    }
    #endregion
}
