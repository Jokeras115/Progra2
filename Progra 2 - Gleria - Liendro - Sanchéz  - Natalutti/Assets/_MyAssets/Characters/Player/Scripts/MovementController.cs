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

    [Header("Private Flaots")]
    [Space]

    private float speed = 15f;
    private float jumpForce = 15f;
    private const float groundcheckRadius = 0.2f;
    private float xMove;

    [Header("Public Floats")]
    [Space]

    public float dashDistance = 15f;

    [Header("Private Bools")]
    [Space]

    private bool facingRight;

    [Header("Public Bools")]
    [Space]

    public bool isGrounded;
    public bool canDoubleJump;
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
    }

    private void BasicMovement()
    {
        #region Movement Logic
        player.rb.velocity = new Vector2(xMove * speed, player.rb.velocity.y);
        player.anim.SetFloat("xVelocity", Mathf.Abs(xMove));
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
}
