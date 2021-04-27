
using UnityEngine;
using System.Collections;

public class MoveItem : MonoBehaviour
{
    public float tubeSpeed;
    private GameManager gm;
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
            return (5 + points) * 1.20f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME &
             gm.gameState != GameManager.GameState.RESUME) return;

        tubeSpeed = CalculateSpeed();

        transform.position += Vector3.left * tubeSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.PlaySFX(pointSFX);
        }
    }
}
