using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_Motion : MonoBehaviour
{
    public float scroll_X = .5f;
    public float scroll_Y = .5f;

    void Start()
    {
        
    }

    void Update()
    {
        float offset_X = Time.time * scroll_X;
        float offset_Y = Time.time * scroll_Y;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset_X, offset_Y);
    }
}
