using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_Sword : MonoBehaviour
{
    public float damageOutput;

    BoxCollider hitBox;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitBox = GetComponent<BoxCollider>();
        hitBox.enabled = false;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().DamageHealth(damageOutput);
        }
    }

    public void SwordAttackEnbable()
    {
        hitBox.enabled = true;
    }

    public void SwordAttackDisable()
    {
        hitBox.enabled = false;
    }

    public void DropSword()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 10f);
    }
}
