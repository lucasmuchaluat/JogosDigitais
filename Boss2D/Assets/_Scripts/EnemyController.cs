using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject bullet;
    private GameManager gm;
    public Transform arma01;
    public int experience;
    private float _lastShootTimestamp = 0.0f;
    public float shootDelay = 2.5f;
    public AudioClip takeDamage;


    // Health Bar
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;


    public void Start()
    {
        gm = GameManager.GetInstance();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        //AudioManager.PlaySFX(shootSFX);

        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        AudioManager.PlaySFX(takeDamage);

        var tempPontos = 5 / (gm.canos + 1);
        if (tempPontos != 0)
        {
            gm.pontos += tempPontos;
        }
        else
        {
            gm.pontos += 1;
        }
        if (currentHealth <= 0) Die();
    }

    public void Die()
    {
        gm = GameManager.GetInstance();
        var player = gm.GetActivePlayer();
        gm.pontos += experience/gm.canos;
        Debug.Log(gm.pontos);
        player.CurrentScore += experience;
        Destroy(gameObject);
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }


    private void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME &
             gm.gameState != GameManager.GameState.RESUME) return;

        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;

        var curry = Posy();
        if (posPlayer.y < curry)
        {
            Thrust(0, -td.thrustIntensity.x);
        }
        else
        {
            Thrust(0, td.thrustIntensity.x);
        }

        Shoot();
    }
}
