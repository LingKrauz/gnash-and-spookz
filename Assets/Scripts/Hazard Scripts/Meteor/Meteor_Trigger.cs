using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Trigger : MonoBehaviour
{
    Meteor meteor;
    public GameObject effects;
    public Renderer meteorRenderer;

    private void Start()
    {
        meteor = GetComponentInParent<Meteor>();

        meteor.enabled = false;
        effects.SetActive(false);
        meteorRenderer.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            meteor.enabled = true;
            effects.SetActive(true);
            meteorRenderer.enabled = true;
        }
    }
}
