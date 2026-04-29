using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabCollision : MonoBehaviour
{
    public SpooksGrab spooksGrab;
    public bool enemyIsCarried;
    public GameObject enemyCarry;
    private GameObject EnemyRef = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyIsCarried == true && Input.GetKeyDown(KeyCode.V))
        {
            EnemyRef.GetComponentInChildren<EnemyThrown>().isThrown = true;
            EnemyRef.GetComponent<Rigidbody>().isKinematic = false;
            EnemyRef.GetComponent<Rigidbody>().AddForce(transform.up * 10f,ForceMode.Impulse);
            
            enemyIsCarried = false;
            enemyCarry.transform.DetachChildren();
            
        }
        if (enemyIsCarried == false)
        {
            EnemyRef = null;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyRef = other.gameObject;
            EnemyRef.GetComponent<Rigidbody>().isKinematic = true;
            EnemyRef.GetComponent<NavMeshAgent>().enabled = false;
            EnemyRef.GetComponent<Enemy>().enabled = false;
            EnemyRef.transform.position = enemyCarry.transform.position;
            EnemyRef.transform.SetParent(enemyCarry.transform);
            enemyIsCarried = true;
            
            


        }
    }
}
