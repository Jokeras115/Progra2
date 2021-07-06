using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public int damage = 5;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        PlayerHealth player = coll.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}