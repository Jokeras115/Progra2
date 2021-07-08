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
    public int node1ID;
    public int node2ID;
    public List<int> medikitsID = new List<int>();
    #endregion

    #region Functions
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Update()
    {
        UpdatePlayerAmmo();
        UpdatePlayerMediPacks();
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
