using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public float damageOutput;

    public GameObject[] parts;
    public GameObject effects;

    AudioSource stalactiteSFX;

    void Start()
    {
        stalactiteSFX = GetComponent<AudioSource>();
        effects.SetActive(false);
    }

    
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<BoxCollider>().enabled = false;

        effects.SetActive(true);
        stalactiteSFX.Play();

        foreach (GameObject part in parts)
        {
            if(part.GetComponent<Rigidbody>() == null)
            {
                part.AddComponent<Rigidbody>();
            }

            Destroy(part, 10f);
        }

        Destroy(effects, 1f);
        Destroy(gameObject, 10f);

        if(collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamageHealth(damageOutput);
        }
    }
}
