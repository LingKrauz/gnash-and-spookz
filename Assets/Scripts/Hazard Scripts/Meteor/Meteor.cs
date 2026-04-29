using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float damageOutput;
    public float speed;

    public GameObject shadowPrefab;
    public Collider trigger;
    public LayerMask masks;

    public bool targetPlayer;
    private bool isMarked;

    [Header("Audio Sources")]
    public AudioSource crashSFX;

    Transform playerRef;
    GameObject shadowObj = null;

    Vector3 playerPos;

    void Start()
    {
        playerRef = FindObjectOfType<PlayerHealth>().transform;
        playerPos = playerRef.position;
        trigger = transform.GetChild(3).GetComponent<Collider>();

        Destroy(gameObject, 15f);
    }

    void Update()
    {
        RaycastHit hit;

        if (targetPlayer)
        {
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }

        Debug.DrawRay(transform.position, transform.forward * 60f, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 60f, masks))
        {
            if (!targetPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);
            }

            if (!isMarked)
            {
                isMarked = true;

                Vector3 markedPos = hit.point;

                shadowObj = Instantiate(shadowPrefab, markedPos, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().DamageHealth(damageOutput);
        }

        crashSFX.Play();
        Destroy(shadowObj);
        Destroy(gameObject, .3f);
    }
}
