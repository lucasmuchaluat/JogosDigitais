using UnityEngine;
using System.Collections;

public class MoveTube : MonoBehaviour
{
    public float tubeSpeed;
    private GameManager gm;
    private bool counted = false;
    private Player player;
    public AudioClip pointSFX;
    public float level;


    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    float CalculateSpeed()
    {
        var points = gm.canos;
        Debug.Log(level);
        if (points < 2)
        {
            return 5;
        }
        else
        {
            return (5+points) * 1.20f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME &
             gm.gameState != GameManager.GameState.RESUME) return;

        tubeSpeed = CalculateSpeed();

        transform.position += Vector3.left * tubeSpeed * Time.deltaTime;

        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;

        var tubeX = transform.position.x;

        if (!counted && tubeX < posPlayer.x)
        {
            gm.canos += 1;
            gm.pontos += 1;

            counted = true;
            AudioManager.PlaySFX(pointSFX);

        }

    }
}
