using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_Says_BTN_Check : MonoBehaviour
{
    public Simon_Says pressCount;

    public int value = 5;
    public bool isSafe;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && pressCount.hasSucceeded == false)
        {
            if (isSafe)
            {
                pressCount.rightSFX.Play();
                pressCount.counter++;
            }

            else
            {
                pressCount.EndChallengeCheck();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isSafe = false;
        }
    }

}
