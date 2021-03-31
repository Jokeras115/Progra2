using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Bools")]
    [Space]
    [SerializeField] bool gameHasEnded = false;
    [SerializeField] bool hasWinGame = false;
    #endregion

    #region Functions
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Lvl01");
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
