using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 12/14/2021 7:38pm MDT
public class Lava : MonoBehaviour
{
    public float timer1;
    public float timer1Set; //length of burn damage effect
    public float timer2;
    public float timer2Set; //interval for taking burn damage

    public PlayerHealth player;
    public PlayerMovement playerSpeed;
    public float burnDamage;
    public bool isInLava;

    public AudioSource burningPlayer;
    public Material isBurning;
    public Material notBurning;

    private bool isParticleOn;
    public GameObject playerAvatar;
    public GameObject statusSpawn;
    public GameObject statusEffect;
    private GameObject spawnParticle;

    void Start()
    {
        player = GameObject.Find("PlayerAvatar").GetComponent<PlayerHealth>();

        timer1 = timer1Set;
        timer2 = timer2Set;

        burningPlayer = gameObject.GetComponent<AudioSource>();

        statusSpawn = GameObject.Find("Status Effect");
    }

    void Update()
    {
        if (isInLava)
        {
            timer1 -= Time.deltaTime;

            if (timer1 <= 0)
            {
                isInLava = false;

                burningPlayer.Stop();

                Destroy(spawnParticle);

                isParticleOn = false;

                playerAvatar.GetComponent<MeshRenderer>().material = notBurning;

                //Player Movement is set back to 11
                playerSpeed.GetComponent<PlayerMovement>().speed = 11;
            }

            timer2 -= Time.deltaTime;

            if (timer2 <= 0)
            {
                player.DamageHealth(burnDamage);
                timer2 = timer2Set;
                burningPlayer.Play();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playerAvatar.GetComponent<MeshRenderer>().material = isBurning;

            //Player Movement speed is set to 8 in the inspector, this will convert it to 15
            playerSpeed.GetComponent<PlayerMovement>().speed = 15;

            isInLava = true;
            timer1 = timer1Set;

            if (!isParticleOn)
            {
                isParticleOn = true;
                spawnParticle = Instantiate(statusEffect, statusSpawn.transform);
            }
        }
    }
}
