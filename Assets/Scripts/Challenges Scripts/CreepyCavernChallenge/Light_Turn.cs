using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Turn : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
