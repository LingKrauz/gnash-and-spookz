using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wizard_Enemy : MonoBehaviour
{
    private enum NavStates { RandomNav, WaypointNav };
    [SerializeField]
    private NavStates currentState;

    [Header("Waypoint Nav")]
    public Transform[] waypoints;
    public Transform[] teleporters;

    [Header("Refrences")]
    public Transform playerRef;
    public Transform effectsPOS;
    public Transform shootPoint;
    public GameObject vanishVFXPrefab;
    public GameObject projectilePrefab;
    public GameObject graphics;
    public GameObject deathEffects;

    public int health;
    private int currentIndex;
    private bool dead;

    [Header("Random Nav")]
    [SerializeField]
    private float wanderRange;
    [SerializeField]
    private float patrolTime;
    private float patrolTimer;
    Vector3 patrolDestination;

    public float attackRange;
    public float fleeRange;
    public float fireRate;
    private float playerDistance;
    private float fireTimer;

    private bool isFleeing;

    NavMeshAgent navAgent;
    Animator anim;

    [Header("Sound Effects")]
    public AudioSource attackSFX;
    public AudioSource hurtSFX;
    public AudioSource hurtSFX2;
    public AudioSource hurtSFX3;
    public AudioSource hurtSFX4;
    public AudioSource detectionSFX;
    public AudioSource vanishSFX;
    public AudioSource deathSFX;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerRef = FindObjectOfType<PlayerHealth>().transform;

        currentIndex = Random.Range(0, waypoints.Length);
        fireTimer = fireRate;
        patrolTimer = patrolTime;
        deathEffects.SetActive(false);
        graphics.SetActive(true);
    }

    void Update()
    {
        if (dead)
        {
            return;
        }

        playerDistance = Vector3.Distance(playerRef.position, transform.position);

        Vector3 playerDir = Vector3.Normalize(playerRef.position - transform.position);
        float dot = Vector3.Dot(transform.forward, playerDir);

        if(dot > 0 && playerDistance < fleeRange)
        {
            navAgent.isStopped = true;
            detectionSFX.Play();

            if(playerDistance >= attackRange)
            {
                if (!isFleeing)
                {
                    Attack();
                }
            }

            else if(playerDistance < attackRange && teleporters.Length > 0)
            {
                StartCoroutine(Fleeing());
            }
        }

        else
        {
            if(currentState == NavStates.WaypointNav)
            {
                if(waypoints.Length > 0)
                {
                    WaypointPatrol();
                }
            }

            else if(currentState == NavStates.RandomNav)
            {
                RandomPatrol();
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
        {
            Death();
            return;
        }

        transform.LookAt(playerRef.position);

        int RNG = Random.Range(2, 5);
        if (RNG == 1)
        {
            hurtSFX.Play();
        }
        else if (RNG == 2)
        {
            hurtSFX2.Play();
        }
        else if (RNG == 3)
        {
            hurtSFX3.Play();
        }
        else if (RNG == 4)
        {
            hurtSFX3.Play();
        }
    }

    public void WaypointPatrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = 2.5f;

        anim.SetBool("isWalking", true);

        if(currentIndex >= waypoints.Length)
        {
            currentIndex = 0;
        }

        navAgent.SetDestination(waypoints[currentIndex].position);
    }

    public void RandomPatrol()
    {
        //playerRef = null;
        navAgent.isStopped = false;

        navAgent.speed = 2f;
        navAgent.stoppingDistance = 0f;

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolTime)
        {
            patrolDestination = RandomNavSphere(transform.position, wanderRange, 3);
            patrolTimer = 0f;
        }

        navAgent.SetDestination(patrolDestination);
        anim.SetBool("isWalking", true);
    }

    public void Attack()
    {
        fireTimer += Time.deltaTime;
        transform.LookAt(playerRef.position);

        anim.SetBool("isWalking", false);

        if(fireTimer >= fireRate)
        {
            anim.SetTrigger("isShooting");
            attackSFX.Play();
            fireTimer = 0f;
        }
    }

    public void Death()
    {
        dead = true;
        deathSFX.Play();
        navAgent.enabled = false;
        anim.SetTrigger("Dead");

        Destroy(gameObject, 6f);
    }

    public void DeathEffect()
    {
        graphics.SetActive(false);
        deathEffects.SetActive(true);
    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == NavStates.WaypointNav)
        {
            if(other.tag == "Waypoint")
            {
                currentIndex++;
            }
        }

        if(other.GetComponent<ProjectileScript>())
        {
            TakeDamage(2);
        }

        if (other.GetComponent<PlayerAttack>())
        {
            TakeDamage(2);
        }
    }

    IEnumerator Fleeing()
    {
        isFleeing = true;
        vanishSFX.Play();

        Instantiate(vanishVFXPrefab, effectsPOS.position, Quaternion.identity);
        transform.GetChild(0).gameObject.SetActive(false);

        int telepoerterIndex = Random.Range(0, teleporters.Length);
        transform.position = teleporters[telepoerterIndex].position;

        yield return new WaitForSeconds(3f);

        transform.GetChild(0).gameObject.SetActive(true);
        Instantiate(vanishVFXPrefab, effectsPOS.position, Quaternion.identity);
        isFleeing = false;
    }
}
