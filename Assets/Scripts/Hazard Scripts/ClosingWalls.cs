using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingWalls : MonoBehaviour
{
    private Animator anim;
    private PlayerHealth player;
    public bool isTouchingLeft;
    public bool isTouchingRight;
    public AudioClip[] clips;
    private AudioSource speaker;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerAvatar").GetComponent<PlayerHealth>();
        anim = gameObject.GetComponent<Animator>();
        speaker = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouchingLeft && isTouchingRight)
        {
            player.DamageHealth(100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("StartClosing", true);
            
        }
    }

    public void ResetStartClosing()
    {
        anim.SetBool("StartClosing", false);
    }

    public void SetWallBool(string wall)
    {
        if (wall == "LeftWall")
        {
            isTouchingLeft = true;
        }
        else
        {
            isTouchingRight = true;
        }
    }

    public void ResetWallBool(string wall)
    {
        if (wall == "LeftWall")
        {
            isTouchingLeft = false;
        }
        else
        {
            isTouchingRight = false;
        }
    }
    public void PlayMovingSound()
    {
        
        speaker.clip = clips[0];
        
        speaker.Play();
    }

    public void PlaySmashSound()
    {
        
        speaker.clip = clips[1];
        speaker.Play();
    }

    public void StopAudio()
    {
        speaker.Stop();
    }

}
