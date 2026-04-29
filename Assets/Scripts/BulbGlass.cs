using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbGlass : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject bulbGlass;
    public AudioSource ASource;
    public AudioClip AClip;
    bool stopSound = false;
    bool CameraOff = false;
    public Animator barAnime;
    
    public GameObject cameraGO;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(!Enemy[0].activeInHierarchy && !Enemy[1].activeInHierarchy && !Enemy[2].activeInHierarchy  && CameraOff == false)
        {   
            PlayerMovement.canMove = false;
            cameraGO.SetActive(true);
            barAnime.SetBool("Play Anim", true);
        }
        if (!bulbGlass.activeInHierarchy & stopSound == false)
        {
            ASource.PlayOneShot(AClip);
            stopSound = true;
        }

    }

    public void DestroyCage()
    {
        bulbGlass.SetActive(false);

    }
    public void NewCamOff()
    {
        PlayerMovement.canMove = true;
        CameraOff = true;
        cameraGO.SetActive(false);
    }
   
}
