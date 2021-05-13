using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Private Variables
    [Header("References")]
    [Space]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private PlayerController player;
    private KeyCode lastKeyCode;

    [Header("Private Flaots")]
    [Space]

    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float jumpForce = 15f;
    private const float groundcheckRadius = 0.2f;
    private float xMove;
    private float doubleTapTime;

    [Header("Public Floats")]
    [Space]

    public float dashDistance = 15f;

    [Header("Private Bools")]
    [Space]


    [Header("Public Bools")]
    [Space]

    public bool isGrounded;
    public bool canDoubleJump;
    public bool isDashing;
    public bool facingRight;
    #endregion

    #region Public Variables
    #endregion

    #region Unity Methods
    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        BasicMovement();
        GroundCheck();
    }
    #endregion

    #region Public Functions
    #endregion

    #region Private Functions
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
        #region Movement Logic
        player.rb.velocity = new Vector2(xMove * speed, player.rb.velocity.y);
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
            player.rb.velocity = Vector2.up * jumpForce;
            canDoubleJump = true;
        }
        else if (canDoubleJump == true)
        {
            player.rb.velocity = new Vector2(player.rb.velocity.x, jumpForce);
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
        player.rb.velocity = new Vector2(player.rb.velocity.x, 0f);
        player.rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = player.rb.gravityScale;
        player.rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        player.rb.gravityScale = gravity;
    }
    #endregion
}
