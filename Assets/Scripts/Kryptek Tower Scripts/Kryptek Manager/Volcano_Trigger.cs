using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano_Trigger : MonoBehaviour
{
    public GameObject volcanoVXF;

    void Start()
    {
        volcanoVXF.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            volcanoVXF.SetActive(true);

            Destroy(gameObject, 8f);
        }
    }
}
