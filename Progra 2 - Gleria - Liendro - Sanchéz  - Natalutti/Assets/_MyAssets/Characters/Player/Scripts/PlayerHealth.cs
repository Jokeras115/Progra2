using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Variables
    [Header("Scripts")]
    public PlayerController controller;
    public GameManager Manager;
    #endregion

    private void Update()
    {
        if(controller.rb.position.y < -10f)
        {
            FindObjectOfType<GameManager>().Fall();
        }
    }
 }
