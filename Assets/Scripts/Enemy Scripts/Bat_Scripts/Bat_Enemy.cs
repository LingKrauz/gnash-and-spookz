using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Enemy : MonoBehaviour
{
    [Header("Reference")]
    public Transform playerRef;
    public AudioSource batAttackSFX;
    public AudioSource batDeathSFX1;
    public AudioSource batDeathSFX2;
    public AudioSource batDeathSFX3;
    public AudioSource batWingsSFX;
    private Animator anim;
    private Rigidbody rb;

    [Header("Health")]
    public int health;

    [Header("Patrol State")]
    public float speed;
    public float angle;
    public bool isPatrolling;
    public bool returnToPost;

    [Header("Chase State")]
    public float chaseDistance;
    public float chaseSpeed;
    public bool isChasing;

    [Header("Attack State")]
    public float attackRate;
    public int attackDamage;

    private bool dead;
    private float time;
    float playerDistance;
    Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerRef = FindObjectOfType<PlayerMovement>().transform;
        startPos = transform.position;
        isPatrolling = true;
        time = 0f;
    }

    
    void Update()
    {
        if (dead)
        {
            return;
        }

        time += Time.deltaTime;

        playerDistance = Vector3.Distance(playerRef.position, transform.position);

        if(playerDistance <= chaseDistance)
        {
            Chase();
        }

        if(playerDistance > chaseDistance)
        {
            isChasing = false;
        }

        if(!isChasing && returnToPost)
        {
            transform.LookAt(startPos);
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (transform.position == startPos)
            {
                transform.rotation = new Quaternion(0f, 0f, 0f, 1);
                isPatrolling = true;
                returnToPost = false;
            }
        }

        if (isPatrolling)
        {
            Patrol();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Death();
        }
    }

    public void Patrol()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(0f, angle * Time.deltaTime, 0f, Space.World);
    }

    public void Chase()
    {
        isChasing = true;
        isPatrolling = false;
        returnToPost = true;

        if (playerDistance <= 1.2f)
        {
            Attack();
        }

        else
        {
            transform.LookAt(playerRef.transform);
            transform.position = Vector3.MoveTowards(transform.position, playerRef.transform.position, chaseSpeed * Time.deltaTime);
        }
    }

    public void Attack()
    {
        transform.LookAt(playerRef.transform);

        if(playerRef.GetComponent<PlayerHealth>() != null)
        {
            if (time >= attackRate && playerRef.GetComponent<PlayerHealth>().health > 0)
            {
                batAttackSFX.Play();
                playerRef.GetComponent<PlayerHealth>().DamageHealth(attackDamage);
                time = 0f;
            }
        }

        if(playerRef.GetComponent<Decoy>() != null)
        {
            if (time >= attackRate && playerRef.GetComponent<Decoy>().health > 0)
            {
                batAttackSFX.Play();
                playerRef.GetComponent<Decoy>().TakeDamage(attackDamage);
                time = 0f;
            }
        }
    }

    public void Death()
    {
        dead = true;
        batWingsSFX.Stop();
        int RNG = (Random.Range(1, 4));
        if (RNG == 1) {
            batDeathSFX1.Play();
        }
        else if (RNG == 2) {
            batDeathSFX2.Play();
        }
        else if (RNG == 3) {
            batDeathSFX3.Play();
        }
        anim.enabled = false;
        rb.isKinematic = false;
        Destroy(gameObject, 8f);
    }
}
