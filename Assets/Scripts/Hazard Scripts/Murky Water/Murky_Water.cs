using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murky_Water : MonoBehaviour
{
    public float damageOutput;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            if(other.GetComponent<PlayerHealth>() != null)
            {
                other.GetComponent<PlayerHealth>().DamageHealth(damageOutput);
            }
        }
    }
}
