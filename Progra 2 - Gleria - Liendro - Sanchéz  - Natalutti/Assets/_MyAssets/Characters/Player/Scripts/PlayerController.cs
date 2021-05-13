using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    [Header("Privates References")]
    [Space]

    private MovementController movement;
    #endregion

    #region Public Variables
    [Header("Public References")]
    [Space]
    public Rigidbody2D rb;
    #endregion

    #region Unity Methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Public Functions
    #endregion

    #region Private Functions
    #endregion
}
