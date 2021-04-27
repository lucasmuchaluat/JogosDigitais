using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbController : SteerableBehaviour, IShooter, IDamageable
{
    private int lifes;
    Animator animator;
    public GameObject bullet;
    public GameObject bullet1;

    public Transform arma01;
    public float shootDelay = 1.0f;
    public AudioClip normalShootSFX;
    public AudioClip powerShootSFX;
    private GameManager gm;
    private float gravity;
    private bool invencible;
    // public float timer = 1;
    private bool maxGun;

    // Timer Bar
    public float maxTimer = 6f;
    public float currentTime;
    public TimeBar timeBar;



    private float _lastShootTimestamp = 0.0f;


    public void Start()
    {
        gm = GameManager.GetInstance();
        gravity = rb.gravityScale;
        animator = GetComponent<Animator>();
        gm.vidas = 1;
        timeBar.gameObject.SetActive(false);
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        if (maxGun & currentTime >= 0)
        {
            AudioManager.PlaySFX(powerShootSFX);
            _lastShootTimestamp = Time.time;
            Instantiate(bullet1, arma01.position, Quaternion.identity);
        }
        else
        {
            AudioManager.PlaySFX(normalShootSFX);
            _lastShootTimestamp = Time.time;
            Instantiate(bullet, arma01.position, Quaternion.identity);
            maxGun = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!invencible)
        {
            gm.vidas -= damage;
            if (gm.vidas <= 0) Die();
        }
        
    }

    public void Die()
    {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        
        if (gm.gameState != GameManager.GameState.GAME &
             gm.gameState != GameManager.GameState.RESUME)
        {
            rb.gravityScale = 0.0f;
            rb.velocity = Vector2.up * 0.0f;
            return;
        }
        animator.SetFloat("Status", 1.0f);


        rb.gravityScale = gravity;

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        //Thrust(xInput, yInput);

        if (yInput != 0 || xInput != 0)
        {
            Shoot();

        }



        if (Input.GetAxisRaw("Jump") != 0)
        {
            animator.SetFloat("Velocity", 1.0f);

            GoUp();
        }
        else
        {
            animator.SetFloat("Velocity", -1.0f);
        }

        // Timer bar
        if(maxGun){
            if (currentTime >= 0)
            {
                currentTime -= Time.deltaTime;
                timeBar.SetTime(currentTime);
            }
            else
            {
                timeBar.gameObject.SetActive(false);
                maxGun = false;
            }
        }
            
    
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Tube"))
        {
            TakeDamage(1);
            invencible = false;
            animator.SetFloat("Powerup", -1.0f);

        }
        if (collision.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            animator.SetFloat("Powerup", 1.0f);
            invencible = true;
            gm.pontos += 5;
        }
        if (collision.CompareTag("PowerupTiro"))
        {
            Destroy(collision.gameObject);
            maxGun = true;

            currentTime = maxTimer;
            timeBar.SetMaxTime(maxTimer);
            
            timeBar.gameObject.SetActive(true);
            gm.pontos += 5;

        }
        if (collision.CompareTag("Poop"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
            if (!invencible)
            {
                gm.pontos -= 100;
            }


        }
    }



}
