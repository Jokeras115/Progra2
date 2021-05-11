using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorReflect : MonoBehaviour
{
    [SerializeField] private Transform pointA;

    [SerializeField] private float speed;

    private Rigidbody2D rb2d;

    private Vector2 toA;

    private Vector2 normal;

    private Vector2 toAReflect;

    private Vector2 direction;

    [SerializeField]
    private float lifeTime = 5f;

    private float currentLifeTime;


    private void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            toA = pointA.position - transform.right;

        toAReflect = Vector2.Reflect(toA.normalized, normal);

        Debug.DrawLine(transform.position, transform.position + (Vector3)normal * 3, Color.red);
        Debug.DrawLine(transform.position, transform.position + (Vector3)toA.normalized * 3, Color.green);
        Debug.DrawLine(transform.position, transform.position + (Vector3)toAReflect.normalized * 3, Color.blue);
        }
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        normal = transform.right;
        direction = transform.right;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = speed * direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        normal = collision.GetContact(0).normal;
        direction = Vector2.Reflect(direction, normal);
       
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += speed * transform.up * Time.deltaTime;
        }
    }
}

