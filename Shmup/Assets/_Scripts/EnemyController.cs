using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject tiro;

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
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
