using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EliteGuard_Enemy : MonoBehaviour
{
    [Header("Refrences")]
    public Transform playerRef;
    public GameObject shieldObj;
    private Rigidbody rb;

    [Header("Combat Settings")]
    public float fOVRange;
    public float attackRange;
    public float attackRate;
    private float playerDistance;
    private float attackTimer;

    [Header("Health Stats")]
    public int health;
    public bool hasNoShield;
    private bool isDead;

    [Header("Audio Sources")]
    public AudioSource hurtSFX;
    public AudioSource shieldHitSFX;
    public AudioSource shieldBreakSFX;
    public AudioSource deathSFX;
    public AudioSource SwordSwingSFX;
    public AudioSource swordDrop1;
    public AudioSource swordDrop2;
    public AudioSource swordDrop3;

    Vector3 guardPos;
    Vector3 playerPos;

    Quaternion guardRot;

    NavMeshAgent navAgent;
    Animator anim;

    Overhead overhead;
    Elite_Sword sword;

    void Start()
    {
        guardPos = transform.position;
        guardRot = transform.rotation;

        playerRef = FindObjectOfType<PlayerHealth>().transform;
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        overhead = GetComponentInChildren<Overhead>();
        sword = GetComponentInChildren<Elite_Sword>();
        rb = GetComponent<Rigidbody>();

        attackTimer = attackRate;

        isDead = false;
    }

    
    void Update()
    {
        if (isDead)
        {
            return;
        }

        playerDistance = Vector3.Distance(playerRef.position, transform.position);

        if(playerDistance <= fOVRange && !overhead.isOverhead && shieldObj != null)
        {
            playerPos = new Vector3(playerRef.position.x, transform.position.y, playerRef.position.z);
            transform.LookAt(playerPos);

            if (playerDistance <= attackRange)
            {
                attackTimer += Time.deltaTime;

                navAgent.isStopped = true;
                anim.SetBool("isBlocking", true);
                anim.SetBool("isGuarding", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true);

                if(attackTimer >= attackRate)
                {
                    Attack();
                }

                return;
            }

            navAgent.isStopped = false;
            navAgent.SetDestination(playerRef.position);

            anim.SetBool("isBlocking", true);
            anim.SetBool("isGuarding", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
        }

        else if (playerDistance <= fOVRange && !overhead.isOverhead && shieldObj == null)
        {
            NoShield();
        }

        else if(playerDistance > fOVRange)
        {
            ReturnToPost();
        }
    }

    public void Attack()
    {
        attackTimer = 0f;

        anim.SetTrigger("Attack");
        anim.SetBool("isGuarding", false);
        anim.SetBool("isBlocking", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isIdle", true);
    }

    public void ReturnToPost()
    {
        if (transform.position.x == guardPos.x)
        {
            transform.rotation = guardRot;
            navAgent.isStopped = true;
            anim.SetBool("isGuarding", false);
            anim.SetBool("isBlocking", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);

            return;
        }

        navAgent.SetDestination(guardPos);
        anim.SetBool("isWalking", true);
        anim.SetBool("isGuarding", true);
        anim.SetBool("isBlocking", false);
        anim.SetBool("isIdle", false);
    }

    public void SwordEnable()
    {
        SwordSwingSFX.Play();
        sword.SwordAttackEnbable();
    }

    public void SwordDisable()
    {
        sword.SwordAttackDisable();
    }

    public void NoShield()
    {
        hasNoShield = true;
        attackRate = .8f;

        playerPos = new Vector3(playerRef.position.x, transform.position.y, playerRef.position.z);
        transform.LookAt(playerPos);

        if (playerDistance <= attackRange)
        {
            attackTimer += Time.deltaTime;

            navAgent.isStopped = true;
            anim.SetBool("isBlocking", false);
            anim.SetBool("isGuarding", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isNoShield", true);

            if (attackTimer >= attackRate)
            {
                Attack();
            }

            return;
        }

        navAgent.isStopped = false;
        navAgent.SetDestination(playerRef.position);

        anim.SetBool("isBlocking", false);
        anim.SetBool("isGuarding", false);
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isNoShield", true);
    }

    public void Death()
    {
        isDead = true;
        navAgent.enabled = false;
        rb.isKinematic = false;
        deathSFX.Play();
        int RNG = Random.Range(1, 4);
        if (RNG == 1)
        {
            swordDrop1.Play();
        }
        else if (RNG == 2)
        {
            swordDrop2.Play();
        }
        else if (RNG == 3)
        {
            swordDrop3.Play();
        }
        sword.DropSword();
        anim.SetTrigger("Dead");
        Destroy(gameObject, 8f);
    }


    public void TakeDamage(int _damage)
    {
        if (!isDead)
        {
            if (hasNoShield)
            {
                health -= _damage;
                hurtSFX.Play();
            }

            if (health <= 0)
            {
                Death();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerAttack>())
        {
            TakeDamage(2);
        }

        if (other.tag == "Projectile")
        {
            TakeDamage(2);
        }
    }
}
