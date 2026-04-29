using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed_Platforms : MonoBehaviour
{
    [Header("Reference")]
    public GameObject[] platforms;
    public Material isReadyMaterial;
    public Material isTriggeredMaterial;
    private Renderer buttonRenderer;
    private Animator anim;
    private AudioSource startTimerSFX;
    public AudioSource triggerButtonSFX;

    [Header("Settings")]
    public float platformTime;
    public bool isTriggered;
    public bool timerStarted;

    private float timeHalf;
    private float timeThird;
    private float timer;
    void Start()
    {
        timer = platformTime;
        timeHalf = platformTime / 2f;
        timeThird = platformTime / 5f;
        isTriggered = false;
        timerStarted = false;
        buttonRenderer = GetComponentInParent<Renderer>();
        anim = GetComponentInParent<Animator>();
        startTimerSFX = GetComponent<AudioSource>();
        //triggerButtonSFX = GetComponentInParent<AudioSource>();

        anim.SetBool("hasStopped", true);
        anim.SetBool("hasStarted", false);
    }

    
    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime;
            buttonRenderer.material = isTriggeredMaterial;

            foreach(GameObject platform in platforms)
            {
                platform.SetActive(true);
            }

            if(timer <= timeHalf)
            {
                startTimerSFX.pitch = 1.25f;

                foreach (GameObject platform in platforms)
                {
                    platform.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, .5f);
                }
            }

            if (timer <= timeThird)
            {
                startTimerSFX.pitch = 1.5f;

                foreach (GameObject platform in platforms)
                {
                    platform.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
                }
            }
        }

        else if (!timerStarted)
        {
            buttonRenderer.material = isReadyMaterial;

            foreach (GameObject platform in platforms)
            {
                platform.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
                platform.SetActive(false);
            }
        }

        TimeCheck();
    }

    public void TimeCheck()
    {
        if(timer <= 0)
        {
            timerStarted = false;
            isTriggered = false;
            timer = platformTime;

            anim.SetBool("hasStopped", true);
            anim.SetBool("hasStarted", false);

            startTimerSFX.Stop();
            startTimerSFX.pitch = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!isTriggered)
            {
                isTriggered = true;
                timerStarted = true;

                anim.SetBool("hasStopped", false);
                anim.SetBool("hasStarted", true);

                startTimerSFX.Play();
                triggerButtonSFX.Play();
            }
        }
    }
}
