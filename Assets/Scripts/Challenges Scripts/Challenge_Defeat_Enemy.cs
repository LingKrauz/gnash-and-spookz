using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_Defeat_Enemy : MonoBehaviour
{
    public Text challengeDesc;
    public Text challengeSimonDesc;
    public Text challengeTargetDesc;
    public bool challengeEnabled;
    public bool isEnemiesDead;
    public bool isTargetsDestroyed;
    public GameObject challengeTrigger;
    public GameObject enemyPortraitPiece;
    public GameObject targetPortraitPiece;
    public int targetScore;
    public int score;

    public AudioSource challengeCompleteSFX;
    void Start()
    {
        enemyPortraitPiece.SetActive(false);
        targetPortraitPiece.SetActive(false);
    }

    
    void Update()
    {
        if(score == 5 && !isEnemiesDead)
        {
            isEnemiesDead = true;
            enemyPortraitPiece.SetActive(true);
            challengeDesc.color = Color.green;
            challengeCompleteSFX.Play();
        }

        if(targetScore == 6 && !isTargetsDestroyed)
        {
            isTargetsDestroyed = true;
            targetPortraitPiece.SetActive(true);
            challengeTargetDesc.color = Color.green;
            challengeCompleteSFX.Play();
        }
    }
}
