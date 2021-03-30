using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    //private first then public ones

    [Header("References")]
    [Space]
    public Rigidbody2D rb;
    //public private Animator anim;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    KeyCode lastKeyCode;

    [Header("Floats")]
    [Space]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private const float groundcheckRadius = 0.2f;
    private float xMove;
    private float doubleTapTime;
    public float dashDistance = 15f;
     
    [Header("Integers")]
    [Space]

    [Header("Bools")]
    [Space]

    private bool facingRight;
    public bool isGrounded;
    public bool canDoubleJump;
    public bool isDashing;
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
        //Move Input
        xMove = Input.GetAxisRaw("Horizontal");

        //Jump Input (Spacebar)
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //Dash Input (double tap A or D)
        if (Input.GetKeyDown(KeyCode.A))
        {
            DashL();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DashR();
        }
    }

    private void BasicMovement()
    {
        #region Move
        if (!isDashing)
        {
            rb.velocity = new Vector2(xMove * speed, rb.velocity.y);
        }
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

    private void DashL()
    {
        //Dash Left
        if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
        {
            StartCoroutine(Dashing(-1f));
        }
        else
        {
            doubleTapTime = Time.time + 0.5f;
        }

        lastKeyCode = KeyCode.A;
    }

    private void DashR()
    {
        //Dash Right
        if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
        {
            StartCoroutine(Dashing(1f));
        }
        else
        {
            doubleTapTime = Time.time + 0.5f;
        }

        lastKeyCode = KeyCode.D;
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

    //Dash Logic (execute in many frames)
    IEnumerator Dashing(float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
    #endregion

    #region Public
    #endregion

    #endregion
}
