using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        Vector2 offset = new Vector2(speed, 0f) * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset += offset;
    }
}