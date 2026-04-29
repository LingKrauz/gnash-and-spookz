using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayerElevator : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            other.transform.parent = gameObject.transform;


        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;


        }
    }
}
