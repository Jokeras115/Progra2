using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    [Space]
    public GameObject pauseMenuUI;

    [Header("Bool")]
    [Space]
    public static bool GameIsPaused = false;

    #region BaseFunctions


    #endregion
    #region MyFunctions



    public void RetryGame()
    { 
        SceneManager.LoadScene("Level01");
    }



    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   
    
        
    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Is Quitting...");
    }
    #endregion
}
