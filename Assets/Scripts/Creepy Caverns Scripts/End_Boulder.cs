using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Boulder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Tumbling_Boulder>())
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<AudioSource>().enabled = false;
        }
    }
}
