using UnityEngine;
using System.Collections;

public class ShotStraight : SteerableBehaviour
{

    private Vector3 direction;
    GameManager gm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage(1);
        }
        if (collision.CompareTag("Tube") || collision.CompareTag("Tiro"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();

        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
        Debug.Log(direction);
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME &
             gm.gameState != GameManager.GameState.RESUME)
        {
            rb.gravityScale = 0.0f;
            rb.velocity = Vector2.up * 0.0f;
            return;
        }

        Thrust(direction.x, 0);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}

