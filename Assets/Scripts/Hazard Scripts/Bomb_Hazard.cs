using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Hazard : MonoBehaviour
{
    [Header("References")]
    public AudioSource fuseSFX;
    public Material defaultMaterial;
    public Material triggeredMaterial;
    public Renderer bombRenderer;
    public GameObject stem;
    public GameObject fuse;
    public GameObject fuseEffects;

    [Header("Settings")]
    public float radius;
    public int damage;
    public float bombTime;
    public bool startTimer;


    private float timer;
    private AudioSource explosionSFX;


    void Start()
    {
        timer = 0f;
        fuseEffects.SetActive(false);
        explosionSFX = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (startTimer)
        {
            BombTimer();
        }
    }

    public void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider objects in colliders)
        {
            PlayerHealth playerhealth = objects.GetComponent<PlayerHealth>();
            Enemy enemyHealth = objects.GetComponent<Enemy>();
            Bat_Enemy batEnemy = objects.GetComponent<Bat_Enemy>();

            if(playerhealth != null)
            {
                playerhealth.DamageHealth(damage);
            }

            else if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            else if(batEnemy != null)
            {
                batEnemy.TakeDamage(damage);
            }

            explosionSFX.Play();
            bombRenderer.enabled = false;
            fuse.SetActive(false);
            stem.SetActive(false);
            fuseEffects.SetActive(false);
            Destroy(gameObject, 1.5f);
        }
    }

    public void BombTimer()
    {
        timer += Time.deltaTime;
        if(timer >= bombTime)
        {
            Detonate();
            timer = 0f;
            startTimer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !startTimer)
        {
            startTimer = true;
            StartCoroutine(BombColorChange());
            fuseEffects.SetActive(true);
            fuseSFX.Play();
        }

        if(other.tag == "Enemy" && !startTimer)
        {
            startTimer = true;
            StartCoroutine(BombColorChange());
            fuseEffects.SetActive(true);
            fuseSFX.Play();
        }

        if (other.tag == "Bat_Enemy" && !startTimer)
        {
            startTimer = true;
            StartCoroutine(BombColorChange());
            fuseEffects.SetActive(true);
            fuseSFX.Play();
        }
    }

    IEnumerator BombColorChange()
    {
        bombRenderer.material = triggeredMaterial;
        yield return new WaitForSeconds(.5f);
        bombRenderer.material = defaultMaterial;
        yield return new WaitForSeconds(.2f);
        bombRenderer.material = triggeredMaterial;
        yield return new WaitForSeconds(.5f);
        bombRenderer.material = defaultMaterial;
        yield return new WaitForSeconds(.2f);
        bombRenderer.material = triggeredMaterial;
        yield return new WaitForSeconds(.4f);
        bombRenderer.material = defaultMaterial;
        yield return new WaitForSeconds(.3f);
        bombRenderer.material = triggeredMaterial;
    }
}
