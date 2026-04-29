using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPhaseChange : MonoBehaviour
{
    public BossScript BS;
    public BossCutsceneManager cutMan;
   
    bool Phase2;
    bool Phase3;
    
    public GameObject FinalBoss;
    public GameObject GnashSpookz;
    
    public GameObject Phase2_WP;
    public GameObject Phase2_WP_GS;
    
    public GameObject Phase3_WP;
    public GameObject Phase3_WP_GS;

    // Start is called before the first frame update
    void Start()
    {   
        Phase2 = false;
        Phase3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BS.bossPhase == 2 && !Phase2)
        {
            cutMan.PlayPhase2();
            Phase2 = true;
        }
        
        if (BS.bossPhase == 3 && !Phase3)
        {
            cutMan.PlayPhase3();
            Phase3 = true;
        }
    }

    public void DoPhase2()
    {
        FinalBoss.GetComponent<NavMeshAgent>().enabled = false;
        FinalBoss.transform.position = Phase2_WP.transform.position;
        GnashSpookz.GetComponent<CharacterController>().enabled = false;
        GnashSpookz.transform.position = Phase2_WP_GS.transform.position;

        FinalBoss.GetComponent<NavMeshAgent>().enabled = true;
        GnashSpookz.GetComponent<CharacterController>().enabled = true;
    }

    public void DoPhase3()
    {
        FinalBoss.GetComponent<NavMeshAgent>().enabled = false;
        FinalBoss.transform.position = Phase3_WP.transform.position;
        GnashSpookz.GetComponent<CharacterController>().enabled = false;
        GnashSpookz.transform.position = Phase3_WP_GS.transform.position;

        FinalBoss.GetComponent<NavMeshAgent>().enabled = true;
        GnashSpookz.GetComponent<CharacterController>().enabled = true;
    }


}
