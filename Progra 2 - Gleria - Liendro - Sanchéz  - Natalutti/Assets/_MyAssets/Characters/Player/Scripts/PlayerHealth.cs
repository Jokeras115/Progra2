using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Variables
    [Header("Scripts")]
    public PlayerController controller;
    public GameManager Manager;
    [SerializeField] Image HPBar;

    [Header("Integers")]
    [Space]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;
    #endregion


    private void Awake()
    {
        health = maxHealth;
    }

    private void Update()
    {
        checkFall();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthBar();
        if (health <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        UpdateHealthBar();
    }

    public void checkFall()
    {
        if (controller.rb.position.y < -10f)
        {
            FindObjectOfType<GameManager>().Fall();
        }
    }

    void Die()
    {
        if(health <= 0)
        {
            Manager.EndGame();
        }
    }

    void UpdateHealthBar()
    {
        Debug.Log((float)health / maxHealth);
        HPBar.fillAmount = (float)health / maxHealth;
    }
}
