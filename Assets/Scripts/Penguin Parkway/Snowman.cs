using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//"The Cursed Script" by Mitchell Kraus. Pick it up in stores this March!

public class Snowman : MonoBehaviour
{
    //aggro variables

    [SerializeField]
    private float aggroDistance;
    [SerializeField]
    private Transform playerTransform;
    private float playerPosition;
    private Vector3 enemyPosition;
    private Vector3 distanceDifference;
    bool isAggroed;
    Animator animator;

    //shooting variables

    public GameObject projectile;
    public Transform spawnPoint;
    public float delayTime;
    float time;
    public bool isShootActive = false;
    //private AudioController soundController;
    public AudioSource snowballSFX;
    public enum abilityState { Shoot, Idle };
    public abilityState currentState;

    //health and damage
    public int health;
    public GameObject healthPackObject;
    void Start()
    {
        time = 0f;
        currentState = abilityState.Idle;
        //soundController = GameObject.Find("AudioSource").GetComponent<AudioController>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        isAggroed = false;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        time += Time.deltaTime;

        playerPosition = Vector3.Distance(playerTransform.position, transform.position);


        if (playerPosition <= 15f)
        {
            transform.LookAt(new Vector3(playerTransform.position.x, gameObject.transform.position.y, playerTransform.position.z), new Vector3(0,1,0));

            if (time >= delayTime)
            {
                currentState = abilityState.Shoot;
                Shoot();
            }
        }

        switch (currentState)
        {
            case abilityState.Shoot:
                Shoot();
                isShootActive = true;
                break;
        }
        
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
        
    }
    private void FixedUpdate()
    {
        /*
        enemyPosition = transform.position;
        playerPosition = playerTransform.position;
        distanceDifference.x = playerPosition.x - enemyPosition.x;
        distanceDifference.z = playerPosition.z - enemyPosition.z;

        if (distanceDifference.z >= aggroDistance || distanceDifference.z >= aggroDistance * -1)
        {
            if (distanceDifference.x >= aggroDistance || distanceDifference.x >= aggroDistance * -1)
            {
                isAggroed = true;
            }
            else
            {
                isAggroed = false;
            }
        }
        else
        {
            isAggroed = false;
        }
        
        if (isAggroed)
        {
            transform.LookAt(playerTransform);
        }
        */
    }
    public void Shoot()
    {
        //Debug.Log("Shoot() activated");
        if (isShootActive)
        {
            //Debug.Log("isShootActive passed");
            //Instantiate(projectile, spawnPoint.position, spawnPoint.rotation.normalized);
            //projectile.transform.position = spawnPoint.transform.position;
            //projectile.transform.rotation = spawnPoint.transform.rotation;
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            //soundController.PlayShooting();
            snowballSFX.Play();
            time = 0f;
            currentState = abilityState.Idle;
            isShootActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            health -= 2;
            if (health == 2)
            {
                animator.SetBool("HitOnce", true);
            }
            if (health < 2)
            {
                animator.SetBool("HitTwice", true);
            }
            int RNG = (Random.Range(1, 4));
            if (RNG == 1)
            {
                Instantiate(healthPackObject.transform, spawnPoint.position, spawnPoint.rotation.normalized);
                healthPackObject.transform.position = spawnPoint.transform.position;
                healthPackObject.transform.rotation = spawnPoint.transform.rotation;
            }
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
