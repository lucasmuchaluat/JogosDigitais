using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour
{
    GameManager gm;
    Vector3 direction;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (GameObject.FindWithTag("Player"))
        {
            Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
            direction = (posPlayer - transform.position).normalized;
            Thrust(direction.x, direction.y);
        }
        
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
