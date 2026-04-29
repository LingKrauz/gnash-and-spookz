using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawningIntro : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Camera;
    public SummonGlassWall triggerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NavBackON()
    {
        triggerScript.animIsPlaying = false;
        PlayerMovement.canMove = true;
        Camera.SetActive(false);
        Enemy.GetComponent<Enemy>().enabled = true;
        Enemy2.GetComponent<Enemy>().enabled = true;
        Enemy3.GetComponent<Enemy>().enabled = true;
        Enemy.GetComponent<NavMeshAgent>().enabled = true;
        Enemy2.GetComponent<NavMeshAgent>().enabled = true;
        Enemy3.GetComponent<NavMeshAgent>().enabled = true;

        gameObject.GetComponent<Animator>().enabled = false;
        
    }
}
