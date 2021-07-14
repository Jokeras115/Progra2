using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;

        public LifeControllerEnemy lifeControllerEnemy;

        public Animator animatorController;

        public Transform player;

        private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
    }
}





