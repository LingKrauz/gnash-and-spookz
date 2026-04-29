using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch_Boulder : MonoBehaviour
{
    public GameObject boulder;

    void Start()
    {
        boulder.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            boulder.SetActive(true);
        }
    }
}
