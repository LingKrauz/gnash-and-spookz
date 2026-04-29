using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePlatform : MonoBehaviour
{
    public GameObject grappleRope;
    private bool isInTrigger;
    public AudioSource sSource;
    public AudioClip spooksClip;
    // Start is called before the first frame update
    void Start()
    {
        grappleRope.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                sSource.PlayOneShot(spooksClip);
                grappleRope.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            grappleRope.SetActive(false);
        }
    }
}
