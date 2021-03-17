using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtaque : State
{   
    GameManager gm;
    SteerableBehaviour steerable;
    IShooter shooter;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public override void Awake()
    {
        base.Awake();

        // Criamos e populamos uma nova transição
        Transition ToPatrulha = new Transition();
        ToPatrulha.condition = new ConditionDistGT(transform,
            GameObject.FindWithTag("Player").transform,
            2.0f);
        ToPatrulha.target = GetComponent<StatePatrulha>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToPatrulha);

        steerable = GetComponent<SteerableBehaviour>();
        
        shooter = steerable as IShooter;
        if(shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }
    }

    public override void Update()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;

        //TODO: Movimentação quando atacando

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
