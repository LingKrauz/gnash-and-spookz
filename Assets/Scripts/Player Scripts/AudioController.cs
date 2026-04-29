using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip[] audioClips;



    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPickupAudio(string item)
    {
        //healthPickup
        if(item == "HealthPickup")
        {
            soundPlayer.clip = audioClips[0];
            soundPlayer.Play();
        }
    

        //WispPickup()
        if(item == "Wisp")
        { 
            soundPlayer.clip = audioClips[1];
            soundPlayer.Play();
        }
    

        //PortraitPickup()
        if(item == "PortraitPiece")
        {
            soundPlayer.clip = audioClips[2];
            soundPlayer.Play();
        }


        //ExtraLife()
        if(item == "ExtraLifePickup")
        {
            soundPlayer.clip = audioClips[9];
            soundPlayer.Play();
        }
        
        //MaxHealthPickup()
        if(item == "MaxHealthPickup")
        {
            soundPlayer.clip = audioClips[14];
            soundPlayer.Play();
        }


    }

    public void PlayHurt()
    {
        soundPlayer.clip = audioClips[3];
        soundPlayer.Play();
    }

    public void PlaySplash()
    {
        soundPlayer.clip = audioClips[4];
        soundPlayer.Play();           
    }
    
    public void PlayPunch()
    {
        soundPlayer.clip = audioClips[5];
        soundPlayer.Play();
    }

    public void PlayJump()
    {
        soundPlayer.clip = audioClips[6];
        soundPlayer.Play();
    }
    public void PlayAirAttack()
    {
        soundPlayer.clip = audioClips[7];
        soundPlayer.Play();
    }

    public void PlayRollAttack()
    {
        soundPlayer.clip = audioClips[8];
        soundPlayer.loop = true;
        soundPlayer.Play();
    }

    public void StopRollAttack()
    {
        soundPlayer.Stop();
        soundPlayer.loop = false;
    }

    public void PlayBubblePop()
    {
        soundPlayer.clip = audioClips[10];
        soundPlayer.Play();
    }

    public void PlayFlapping()
    {
        soundPlayer.clip = audioClips[11];
        soundPlayer.Play();
    }

    public void PlayGroundPound()
    {
        soundPlayer.clip = audioClips[12];
        soundPlayer.Play();
    }

    public void PlayShooting()
    {
        soundPlayer.clip = audioClips[13];
        soundPlayer.Play();
    }

    public void PlayDash()
    {
        soundPlayer.clip = audioClips[15];
        soundPlayer.Play();
    }

    public void PlaySpinAttack()
    {
        soundPlayer.clip = audioClips[16];
        soundPlayer.Play();
    }
}
