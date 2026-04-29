using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Spike_Hazard : MonoBehaviour
{
    [Header("Settings")]
    public float speed;
    public float spikeRate;
    public int spikeDamage;

    [Header("Groups")]
    public bool groupA;
    public bool groupB;


    private bool isUp;
    private bool isDown;
    private float aTimer;
    private float bTimer;
    private AudioSource spikeUpSFX;

    void Start()
    {
        aTimer = 0f;
        bTimer = 0f;

        spikeUpSFX = GetComponent<AudioSource>();
    }


    void Update()
    {
        aTimer += Time.deltaTime;
        bTimer += Time.deltaTime;


        if (groupA && aTimer >= spikeRate)
        {
            GroupAClass();
        }

        if (groupB && bTimer >= spikeRate)
        {
            GroupBClass();
        }
    }


    public void GroupAClass()
    {
        if (transform.localPosition.y <= -12.5f)
        {
            aTimer = 0f;
            isDown = false;
            isUp = true;
        }

        if (transform.localPosition.y >= 0f)
        {
            aTimer = 0f;
            isUp = false;
            isDown = true;

            spikeUpSFX.Play();
        }

        if (isUp)
        {
            transform.localPosition += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if (isDown)
        {
            transform.localPosition -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }

    public void GroupBClass()
    {
        if (transform.localPosition.y <= -12.5f)
        {
            bTimer = 0f;
            isDown = false;
            isUp = true;
        }

        if (transform.localPosition.y >= 0f)
        {
            bTimer = 0f;
            isUp = false;
            isDown = true;

            spikeUpSFX.Play();
        }

        if (isUp)
        {
            transform.localPosition += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if (isDown)
        {
            transform.localPosition -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DamageHealth(spikeDamage);
        }
    }
}
