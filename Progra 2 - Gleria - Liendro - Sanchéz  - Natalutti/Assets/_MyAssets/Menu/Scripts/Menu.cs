using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Lvl01");
    }

    public void Salir()

    {
        Application.Quit();
        Debug.Log("Quit");
    }
}