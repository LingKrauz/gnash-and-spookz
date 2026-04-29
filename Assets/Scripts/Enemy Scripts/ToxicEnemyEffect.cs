using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicEnemyEffect : MonoBehaviour
{
    public float toxicDamage;
    float time;
    [SerializeField]
    public float damageRate;

    public PlayerMovement playerSpeed;

    public Material isToxified;
    public Material notToxified;

    private bool isParticleOn;

    public GameObject playerAvatar;
    public GameObject statusSpawn;
    public GameObject statusEffect;
    private GameObject spawnParticle;

    public AudioSource toxicPlayer;

    public GameObject enemy = null;



    void Start()
    {
        toxicPlayer = gameObject.GetComponent<AudioSource>();

        time = 0f;

        statusSpawn = GameObject.Find("Status Effect");
    }

    void Update()
    {
        time += Time.deltaTime;

        if (enemy == null)
        {
            playerAvatar.GetComponent<MeshRenderer>().material = notToxified;

            //Player Movement is set back to 11
            playerSpeed.GetComponent<PlayerMovement>().speed = 11;

            Destroy(spawnParticle);

            isParticleOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ToxicEnemy")
        {
            enemy = other.gameObject;

            ToxicWasteDamage();
            playerAvatar.GetComponent<MeshRenderer>().material = isToxified;

            //Player Movement speed is set to 11 in the inspector, this will convert it to 6
            playerSpeed.GetComponent<PlayerMovement>().speed = 6f;

            if (!isParticleOn)
            {
                isParticleOn = true;
                spawnParticle = Instantiate(statusEffect, statusSpawn.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ToxicEnemy")
        {
            playerAvatar.GetComponent<MeshRenderer>().material = notToxified;

            //Player Movement is set back to 11
            playerSpeed.GetComponent<PlayerMovement>().speed = 11;

            Destroy(spawnParticle);

            isParticleOn = false;
        }
    }

    public void ToxicWasteDamage()
    {
        if (time >= damageRate && playerAvatar.GetComponent<PlayerHealth>().health > 0)
        {
            toxicPlayer.Play();

            playerAvatar.GetComponent<PlayerHealth>().DamageHealth(toxicDamage);

            time = 0f;
        }
    }
}
