using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    [Range(1, 10)]
    public float velocidade;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        // if (gm.gameState != GameManager.GameState.GAME) return;
        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
    }
}
