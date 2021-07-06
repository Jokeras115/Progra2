using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 600;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    

    private Rigidbody2D rb2d;
    private Transform groundCheck;
    private bool facingRight = true;
    private bool jump;
    private bool onGround = false;
    private float hForce = 0;
    private float fireRate = 0.2f;
    private float nextFire;

    private bool isDead = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    private void Update()
    {
        if (!isDead)
        {
            onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                jump = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (rb2d.velocity.y > 0)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
                }
            }
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            if (!facingRight)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            hForce = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(hForce * speed, rb2d.velocity.y);
           
            if (hForce > 0 && !facingRight)
            {
                Flip();
            }
            else if (hForce < 0 && facingRight)
            {
                Flip();
            }
            if (jump)
            {
                jump = false;
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}