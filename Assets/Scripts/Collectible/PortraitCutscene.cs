using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitCutscene : MonoBehaviour
{
    public Animator cutAnim;
    public GameObject cutCam;
    public AudioSource cutPlayer;
    public Animator pAnim;
    public GameObject Player;

    void Start()
    {   
        cutAnim = gameObject.GetComponent<Animator>();
        cutPlayer = gameObject.GetComponent<AudioSource>();
        cutCam.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PlayCutscene()
    {

        PlayerHealth.isInCutscene = true;
        cutCam.SetActive(true);
        cutPlayer.Play();
        PlayerMovement.canMove = false;
    }

    public void StopCutscene()
    {
        PlayerHealth.isInCutscene = false;
        PlayerMovement.canMove = true;
        cutCam.SetActive(false);
        pAnim.SetBool("doCelebrate", false);
    }
}
