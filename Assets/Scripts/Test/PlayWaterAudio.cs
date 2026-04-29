using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterAudio : MonoBehaviour
{
    //public GameObject nose;
    public WaterScript water;
    public bool isSwimming;
    public bool isPlaying;
    public AudioController audioCon;
    public float timer;
    public float timerSet = 2f;
    public bool notBreathing;
    public int bubbleCount = 4;

    // Start is called before the first frame update
    void Start()
    {
        //nose = GameObject.Find("Nose");
        water = GameObject.Find("PlayerAvatar").GetComponent<WaterScript>();
        audioCon = GameObject.Find("AudioSource").GetComponent<AudioController>();
        timer = timerSet;
    }

    // Update is called once per frame
    void Update()
    {
        isSwimming = water.isunderWater;
        notBreathing = isSwimming;

        if(isSwimming && !isPlaying)
        {
            isPlaying = true;
            gameObject.GetComponent<AudioSource>().Play();
            

        }
        else if(!isSwimming && isPlaying)
        {
            isPlaying = false;
            gameObject.GetComponent<AudioSource>().Stop();
            timer = timerSet;
            bubbleCount = 4;
        }

        

    }

    private void FixedUpdate()
    {
        
        if(notBreathing && bubbleCount > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                bubbleCount--;
                audioCon.PlayBubblePop();
                timer = timerSet;
            }
        }
    }





}
