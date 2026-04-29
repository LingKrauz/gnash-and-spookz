using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpooksGrab : MonoBehaviour
{
    public AudioSource sSource;
    public AudioClip GrabSound;
    public bool Grab =false;
    public GameObject spooksGrab;
    public GrabCollision grabCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Grab == false && Input.GetKeyDown(KeyCode.V))
        {
            sSource.PlayOneShot(GrabSound);
            spooksGrab.SetActive(true);
            StartCoroutine(ReturnGrabNoraml());
            
        }

    }
  
    IEnumerator ReturnGrabNoraml()
    {
        yield return new WaitForSeconds(.2f);
        spooksGrab.SetActive(false);
    }

}
