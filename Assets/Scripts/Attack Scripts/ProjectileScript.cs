using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Mitchell Kraus 12/5/21

public class ProjectileScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float lifeDuration;
    float time;
    [SerializeField]
    private int damageValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        rb.velocity = transform.forward * speed;

        if (time >= lifeDuration)
        {
            Destroy(gameObject);
            time = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            if (other.GetComponent<Enemy>() != null)
            {
                other.GetComponent<Enemy>().TakeDamage(damageValue);
            }
            Destroy(gameObject);
        }
    }
}
