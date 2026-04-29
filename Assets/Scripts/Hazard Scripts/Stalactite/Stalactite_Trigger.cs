using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite_Trigger : MonoBehaviour
{
    public Rigidbody rb;

    public AudioSource triggerSFX;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>() != null)
        {
            triggerSFX.Play();
            rb.isKinematic = false;
            gameObject.SetActive(false);
        }
    }
}
