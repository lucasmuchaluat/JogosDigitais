using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : SteerableBehaviour, IDamageable
{

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

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
