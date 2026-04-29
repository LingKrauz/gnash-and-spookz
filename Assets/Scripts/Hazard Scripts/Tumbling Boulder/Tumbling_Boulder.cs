using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbling_Boulder : MonoBehaviour
{
    public int damageOutput;

    public bool isDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Booster")
        {
            float tempSpeed;
            tempSpeed = other.GetComponent<Booster>().speed;

            if (isDirection)
            {
                isDirection = false;
                rb.velocity += Vector3.forward * tempSpeed * Time.deltaTime;
            }

            else
            {
                isDirection = true;
                rb.velocity += -Vector3.forward * tempSpeed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerHealth>())
        {
            if (collision.collider.GetComponent<PlayerHealth>() != null)
            {
                collision.collider.GetComponent<PlayerHealth>().DamageHealth(damageOutput);
            }
        }
    }
}
