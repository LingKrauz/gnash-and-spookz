using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour
{
    public int health;

    private AudioSource deployDecoySFX;
    void Start()
    {
        deployDecoySFX = GetComponent<AudioSource>();
        deployDecoySFX.Play();
    }

    
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;
    }

    
}
