using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float speed = 10;
    public int damage = 10;
    public float destroyTime = 1.5f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyController>().lifeControllerEnemy.GetDamage(damage);
        }
        else if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }

}







