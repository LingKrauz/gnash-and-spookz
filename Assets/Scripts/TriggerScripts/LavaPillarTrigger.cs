using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPillarTrigger : MonoBehaviour
{
    public Animator pAnim;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            pAnim.SetBool("isOnPlatform", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            pAnim.SetBool("isOnPlatform", false);
        }
    }
}
