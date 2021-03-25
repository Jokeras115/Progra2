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

    private float xMove;
    private const float groundcheckRadius = 0.2f;
    private const float overheadCheckRadius = 0.2f;
    public float speed = 5f;
    public float jumpForce = 5f;

    /*[Header("Integers")]
    [Space]
    */
    [Header("Bools")]
    [Space]

    [SerializeField] private bool facingRight;
    [SerializeField] bool Jump;
    public bool isGrounded;
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
        Movement(Jump);
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
            Jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            Jump = false;
        }
    }

    private void Movement(bool jumpFlag)
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

        #region Jump

        if (isGrounded)
        {
            if (jumpFlag)
            {
                jumpFlag = false;
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        #endregion
    }

    private void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundcheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
    }
    #endregion

    #region Public
    #endregion

    #endregion
}
