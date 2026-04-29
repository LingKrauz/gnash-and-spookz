using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimonSays : MonoBehaviour
{
    private Simon_Says simon;
    // Start is called before the first frame update
    void Start()
    {
        simon = GetComponentInParent<Simon_Says>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            simon.TriggerStartCoroutine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            simon.TriggerStopCoroutine();
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
