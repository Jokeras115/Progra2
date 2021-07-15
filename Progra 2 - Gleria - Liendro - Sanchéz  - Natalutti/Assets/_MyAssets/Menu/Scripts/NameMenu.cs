using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameMenu : MonoBehaviour
{
    public Text input;
    private void Start()
    {
    }
    public void OKButton()
    {
        if (input.text == "")
        {
            var nameCollection = new NamesBaseCollection();
            GameManager.managerInstance.playerName = nameCollection.GetRandomName();
        }
        else
            GameManager.managerInstance.playerName = input.text;

        GameManager.managerInstance.StartGame();
    }
    public void CANCELButton()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
