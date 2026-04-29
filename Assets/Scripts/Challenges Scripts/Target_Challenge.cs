using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Challenge : MonoBehaviour
{
    public Collider airAttack1;
    public Collider airAttack2;

    public Challenge_Defeat_Enemy challenge;

    public AudioSource targetBreakSFX;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == airAttack1)
        {
            targetBreakSFX.Play();
            challenge.targetScore++;
            Destroy(gameObject);
            challenge.challengeTargetDesc.text = "-Destroy 6 Targets in this area: " + challenge.targetScore.ToString() + "/" + "6";
        }
    }
}
