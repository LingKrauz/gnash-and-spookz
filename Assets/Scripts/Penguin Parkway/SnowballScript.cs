using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float lifeDuration;
    float time;
    [SerializeField]
    private int damageValue;
    public LayerMask mask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        //rb.velocity = transform.forward * speed;

        if (time >= lifeDuration)
        {
            Destroy(gameObject);
            time = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            other.GetComponent<PlayerHealth>().DamageHealth(damageValue);
            Destroy(gameObject);
        }
      
        else if (other.gameObject.layer == 6 || other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
        
    }
}
