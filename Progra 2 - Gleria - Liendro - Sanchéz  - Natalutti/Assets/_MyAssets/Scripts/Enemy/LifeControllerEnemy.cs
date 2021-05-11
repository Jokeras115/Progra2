using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LifeControllerEnemy : MonoBehaviour
    {
        [SerializeField] private int maxLife;

        public int currentLife;
        private int armor;

        private void Start()
        {
            currentLife = maxLife;
        }

        public void GetDamage(int damage)
        {
            if (damage > armor)
            {
                currentLife -= damage - armor;

                if (currentLife <= 0)
                {
                    Kill();
                }
            }

        }

        public void GetHeal(int heal)
        {
            if (currentLife < maxLife)
            {
                currentLife += heal;

                if (currentLife > maxLife)
                {
                    currentLife = maxLife;
                }
            }
        }

        private void Kill()
        {
            Destroy(gameObject);
        }
    }


