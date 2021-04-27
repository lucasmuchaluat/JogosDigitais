
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> items;
    public float height;
    public float maxTimer = 1;
    public float timer = 1;
    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME &
             gm.gameState != GameManager.GameState.RESUME) return;

        var index = Random.Range(0, items.Count);

        if (timer > maxTimer)
        {
            GameObject newItem = Instantiate(items[index]);
            newItem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newItem, 20);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
