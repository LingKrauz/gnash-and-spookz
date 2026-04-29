using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_Trigger : MonoBehaviour
{
    public Challenge_Defeat_Enemy challenges;
    public GameObject challenge_Manager;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !challenges.challengeEnabled)
        {
            challenge_Manager.SetActive(true);
            challenges.challengeEnabled = true;
            challenges.challengeDesc.text = "-Defeat 5 Enemies in this area: " + challenges.score.ToString() + "/" + "5";
            challenges.challengeSimonDesc.text = "-Complete the Simon Says Challenge.";
            challenges.challengeTargetDesc.text = "-Destroy 6 Targets in this area: " + challenges.targetScore.ToString() + "/" + "6";
        }
    }
}
