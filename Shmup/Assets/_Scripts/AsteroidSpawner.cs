using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject Asteroid;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            for(int j = 0; j < 2; j++){
                float number = Random.Range(0.0f, 4.0f);
                Vector3 posicao = new Vector3(5 +  10f * i, 2 - number * j);
                Instantiate(Asteroid, posicao, Quaternion.identity, transform);
            }
        }
    }
}
