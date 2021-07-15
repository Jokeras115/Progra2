using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        GameManager.managerInstance.AskPlayerName();
    }
    public void ExitButton()
    {
        GameManager.managerInstance.QuitGame();
    }
}
