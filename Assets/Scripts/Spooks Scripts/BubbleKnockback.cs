using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BubbleKnockback : MonoBehaviour
{
    public AudioSource sSource;
    public AudioClip spooksClip;
    private float shieldTimer;
    private float shieldCooldown;
  
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {

            
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<Enemy>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(Vector3.back *300f);
            
            
        }
      
    }
    

    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            yield return new WaitForSeconds(0.5f);
            other.GetComponent<NavMeshAgent>().enabled = true;
            other.GetComponent<Enemy>().enabled = true;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    
    }
    
}
