using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{   
    GameManager gm;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            gm = GameManager.GetInstance();
            gm.pontos+=50;
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        if (gm.pontos >= 1000)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        Thrust(1, 0);
    }

}
