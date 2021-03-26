using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("References")]
    [Space]
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Animator anim;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("Floats")]
    [Space]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private float xMove;
    private const float groundcheckRadius = 0.2f;

    [Header("Integers")]
    [Space]

    [Header("Bools")]
    [Space]

    private bool facingRight;
    public bool isGrounded;
    public bool canDoubleJump;
    #endregion
    #region BaseFunctions
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        BasicMovement();
        GroundCheck();
    }
    #endregion

    #region MyFunctions

    #region Private
    private void Inputs()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void BasicMovement()
    {
        #region Move
        rb.velocity = new Vector2(xMove * speed, rb.velocity.y);
        #endregion

        #region Flip
        if (facingRight && xMove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && xMove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        #endregion

    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            canDoubleJump = true;
        }
        else if(canDoubleJump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            canDoubleJump = false;
        }
    }
    private void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundcheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }         
    }

    #endregion

    #region Public
    #endregion

    #endregion
}
