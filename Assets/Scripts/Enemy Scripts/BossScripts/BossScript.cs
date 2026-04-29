using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This is James' code, modified to work with the boss

public class BossScript : MonoBehaviour
{
    private enum NavStates { RandomNav, WaypointNav };
    [SerializeField]
    private NavStates currentState;

    [Header("Boss Configuration")]
    public bool isPaused = false;
    public int bossPhase = 1;
    public int phaseTwoHealth;
    public int phaseThreeHealth;
    public int health;

    [Header("Teleporters")]
    public Transform[] teleporters;
    public Transform[] phaseTwoTeleporters;
    public Transform[] phaseThreeTeleporters;

    [Header("Refrences")]
    public Transform playerRef;
    public Transform effectsPOS;
    public Transform shootPoint;
    public Transform minionSpawnPoint;
    public GameObject vanishVFXPrefab;
    public GameObject projectilePrefab;
    public GameObject batPrefab;
    public GameObject eliteGuardPrefab;
    public GameObject wizardPrefab;
    public GameObject normalEnemyPrefab;
    Vector3 playerPos;
    public BossHealthBar bossHealthBar;
    public BossCutsceneManager cutMan;
    private int currentIndex;

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
    public AudioSource detectionSFX;
    public AudioSource vanishSFX;
    public AudioSource deathSFX;

    [Header("Waypoints (Don't use)")]
    public Transform[] waypoints;

    public Animator bAnim;
    private GameObject currSpawn;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerRef = FindObjectOfType<PlayerHealth>().transform;

        currentIndex = Random.Range(0, waypoints.Length);
        fireTimer = fireRate;
        patrolTimer = patrolTime;
        bossHealthBar.SetMaxHealth(health);
    }

    void Update()
    {
        if (health <= phaseTwoHealth && health > phaseThreeHealth)
        {
            bossPhase = 2;
        }
        else if (health <= phaseThreeHealth)
        {
            bossPhase = 3;
        }

        if (!isPaused)
        {
            playerDistance = Vector3.Distance(playerRef.position, transform.position);
            Vector3 playerDir = Vector3.Normalize(playerRef.position - transform.position);
            navAgent.isStopped = true;
            detectionSFX.Play();

            if (!isFleeing)
            {
                Attack();
            }
            if (playerDistance < attackRange && teleporters.Length > 0)
            {
                StartCoroutine(Fleeing());
            }
        }
        playerPos = new Vector3(playerRef.position.x, transform.position.y, playerRef.position.z);
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
        bossHealthBar.SetHealth(health);
        int RNG = Random.Range(1, 4);
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
        StartCoroutine(Fleeing());

        if (health <= 0)
        {
            isPaused = true;
            bAnim.SetBool("isDead", true);
            cutMan.PlayPhase4();

            return;
        }

        transform.LookAt(playerRef.position);

        
    }

    public void KillBoss()
    {
        deathSFX.Play();
        Destroy(gameObject, 4f);

    }

    public void WaypointPatrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = 2.5f;

        anim.SetBool("isWalking", true);

        if (currentIndex >= waypoints.Length)
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
        transform.LookAt(playerPos);

        anim.SetBool("isWalking", false);

        if (fireTimer >= fireRate)
        {
            anim.SetTrigger("isShooting");
            fireTimer = 0f;
        }
    }

    public void Shoot()
    {
        if (bossPhase == 1)
        {
            bAnim.SetTrigger("doShoot");
            
        }
        if (bossPhase == 2)
        {
            fireRate = 5;
            bAnim.SetTrigger("doSpawn");
            var enemy = (Random.Range(1, 3));
            if (enemy == 1)
            {
                currSpawn = batPrefab;
                
            }
            else if (enemy == 2)
            {
                var guardcheck = (Random.Range(1, 5));
                if (guardcheck == 1 || guardcheck == 2 || guardcheck == 3)
                {
                    currSpawn = eliteGuardPrefab;
                    
                }
                else if (guardcheck == 4)
                {
                    currSpawn = normalEnemyPrefab;
                }
            }
        }
        if (bossPhase == 3)
        {
            fireRate = 1;
            var enemy = (Random.Range(1, 5));
            if (enemy == 1)
            {
                bAnim.SetTrigger("doSpawn");
                currSpawn = batPrefab;
            }
            else if (enemy == 2 || enemy == 3)
            {
                bAnim.SetTrigger("doSpawn");
                currSpawn = normalEnemyPrefab;
            }
            else if (enemy == 4)
            {
                bAnim.SetTrigger("doShoot");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == NavStates.WaypointNav)
        {
            if (other.tag == "Waypoint")
            {
                currentIndex++;
            }
        }

        if (other.GetComponent<ProjectileScript>())
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

        if (bossPhase == 1)
        {
            int telepoerterIndex = Random.Range(0, teleporters.Length);
            transform.position = teleporters[telepoerterIndex].position;
        }
        else if (bossPhase == 2)
        {
            int telepoerterIndex2 = Random.Range(0, phaseTwoTeleporters.Length);
            transform.position = phaseTwoTeleporters[telepoerterIndex2].position;
        }
        else if (bossPhase == 3)
        {
            int telepoerterIndex3 = Random.Range(0, phaseThreeTeleporters.Length);
            transform.position = phaseThreeTeleporters[telepoerterIndex3].position;
        }

        yield return new WaitForSeconds(3f);

        transform.GetChild(0).gameObject.SetActive(true);
        Instantiate(vanishVFXPrefab, effectsPOS.position, Quaternion.identity);
        isFleeing = false;
    }


    public void SpawnEnemy()
    {
        Instantiate(currSpawn, minionSpawnPoint.position, Quaternion.identity);
    }

    public void ShootProjectile()
    {
        if (shootPoint.gameObject.activeSelf)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            attackSFX.Play();
        }

        //int attackSFXRNG = Random.Range(1, 3);
        //if (attackSFXRNG == 1)
        //{
        //}
    }
}
