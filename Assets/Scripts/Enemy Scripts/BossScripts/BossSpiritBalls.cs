using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritBalls : MonoBehaviour
{
    public float damageOutput;
    public float speed;
    public float lifeTime;

    Transform playerRef;

    void Start()
    {
        playerRef = FindObjectOfType<PlayerHealth>().transform;
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        transform.LookAt(playerRef.position);
        transform.position = Vector3.MoveTowards(transform.position, playerRef.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().DamageHealth(damageOutput);
        }

        Destroy(gameObject);
    }
}
