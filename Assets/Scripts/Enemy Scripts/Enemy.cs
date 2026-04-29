using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Script Made BY: James Ostrander

public class Enemy : MonoBehaviour
{
    AudioSource enemyNoiseSFX;

    NavMeshAgent navAgent;
    // Initilize the position of the player.
    public Transform playerRef;

    private enum NavStates { RandomNav, WaypointNav };
    [SerializeField]
    private NavStates currentSate;

    [Header("Waypoint Nav")]
    // List positions for the enemy to move to.
    [SerializeField]
    private Transform[] waypoints;

    // Get the current waypoint in the waypoints[] array.
    public int currentWaypointIndex;

    // Obtain the attack trigger Gameobject.
    [SerializeField]
    private GameObject attackTrigger;

    public Challenge_Defeat_Enemy enemyChallenge;

    // Check if the playerRef is valid or not.
    public bool isPlayer;

    // Set enemy health value.
    [SerializeField]
    public int health;

    // Set a rate of time for the enemy to attack.
    [SerializeField]
    private float attackRate;

    // How much damage will the enemy give the player.
    [SerializeField]
    private int damageApplied;

    [Header("Random Nav")]
    [SerializeField]
    private float wanderRange;

    [SerializeField]
    private float patrolTime;

    private float patrolTimer;

    Vector3 patrolDestination;

    // Time frame for checking the Attack Rate.
    float time;
    
    //Knockback Boolean and Vector3
    public bool knockBack;

    float playerDistance;

    public AudioSource hurt1SFX;
    public AudioSource hurt2SFX;
    public AudioSource hurt3SFX;

    void Start()
    {
        enemyNoiseSFX = GetComponent<AudioSource>();
        navAgent = GetComponent<NavMeshAgent>();
        playerRef = null;
        currentWaypointIndex = 0;
        navAgent.stoppingDistance = 0f;

        time = 0f;
        patrolTimer = patrolTime;

        knockBack = false;
    }

    void Update()
    {
        // Set variable time to the time speed for the CPU to create same instance across machines.
        time += Time.deltaTime;

        // If the player is found then chase the player.
        if (isPlayer)
        {
            Chase();
        }

        // If not, then set the enemy into Patrol.
        else
        {
            if(currentSate == NavStates.RandomNav)
            {
                RandomPatrol();
            }

            if(currentSate == NavStates.WaypointNav)
            {
                if (waypoints.Length > 0)
                {
                    WayPointPatrol();
                }
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
            if (enemyChallenge != null)
            {

                if (enemyChallenge.challengeEnabled && enemyChallenge.score <= 5)
                {
                    enemyChallenge.score++;
                    enemyChallenge.challengeDesc.text = "-Defeat 5 Enemies in this area: " + enemyChallenge.score.ToString() + "/" + "5";
                }
            }
            
            int RNG = Random.Range(1, 4);
            if (RNG == 1)
            {
                hurt1SFX.Play();
            }
            else if (RNG == 2)
            {
                hurt2SFX.Play();
            }
            else if (RNG == 3)
            {
                hurt3SFX.Play();
            }

            StartCoroutine(Death());
        }

        else
        {
            int RNG = Random.Range(1, 4);
            if (RNG == 1)
            {
                hurt1SFX.Play();
            }
            else if (RNG == 2)
            {
                hurt2SFX.Play();
            }
            else if (RNG == 3)
            {
                hurt3SFX.Play();
            }
        }
    }

    public void WayPointPatrol()
    {
        playerRef = null;
        navAgent.isStopped = false;

        if (currentWaypointIndex == waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        navAgent.speed = 2f;
        navAgent.stoppingDistance = 0f;
        navAgent.SetDestination(waypoints[currentWaypointIndex].position);

        // Revised the waypoint system. Now is communicated with the waypoint script.
    }

    public void RandomPatrol()
    {
        playerRef = null;
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
    }

    public void Chase()
    {
        if (playerRef != null)
        {
            playerDistance = Vector3.Distance(playerRef.position, transform.position);


            transform.LookAt(new Vector3(playerRef.position.x, transform.position.y, playerRef.position.z));

            navAgent.speed = 3f;
            navAgent.stoppingDistance = 2f;

            if (playerDistance > navAgent.stoppingDistance)
            {
                navAgent.isStopped = false;
                navAgent.SetDestination(playerRef.position);
                attackTrigger.SetActive(false);
            }

            else
            {
                navAgent.isStopped = true;
                Attack();
            }
        }

        else
        {
            isPlayer = false;
        }
    }

    public void Attack()
    {
        if (playerRef != null)
        {
            if (playerRef.GetComponent<PlayerHealth>() != null)
            {
                if (time >= attackRate && playerRef.GetComponent<PlayerHealth>().health > 0)
                {
                    attackTrigger.SetActive(true);
                    playerRef.GetComponent<PlayerHealth>().DamageHealth(damageApplied);
                    enemyNoiseSFX.Play();
                    time = 0f;
                }

                else
                {
                    attackTrigger.SetActive(false);
                }
            }

            if(playerRef.GetComponent<Decoy>() != null)
            {
                if (time >= attackRate && playerRef.GetComponent<Decoy>().health > 0)
                {
                    attackTrigger.SetActive(true);
                    playerRef.GetComponent<Decoy>().TakeDamage(damageApplied);
                    enemyNoiseSFX.Play();
                    time = 0f;
                }

                else
                {
                    attackTrigger.SetActive(false);
                }
            }

            else
            {
                attackTrigger.SetActive(false);
            }
        }

        else
        {
            isPlayer = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerRef = other.transform;
            isPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerRef = null;
            isPlayer = false;
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
