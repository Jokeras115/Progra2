using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    [Header("Privates Variables")]
    [Space]

    private float nextFire;
    private float fireRate = 0.2f;
    [Header("Privates References")]
    [Space]

    private MovementController movement;
    #endregion

    #region Public Variables
    [Header("Public References")]
    [Space]
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    #endregion

    #region Unity Methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<MovementController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            if (!movement.facingRight)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
    }
    #endregion

    #region Public Functions
    #endregion

    #region Private Functions
    #endregion
}
