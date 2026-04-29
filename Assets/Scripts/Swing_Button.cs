using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing_Button : MonoBehaviour
{
    private GameObject pivot;
    public Material activeMaterial;
    public AudioSource triggerButtonSFX;
    bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        pivot = GameObject.Find("Pivot");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pivot.GetComponent<Animator>().enabled = true;
            GetComponent<Renderer>().material = activeMaterial;
            if (!isOn)
            {
                triggerButtonSFX.Play();
            }
            isOn = true;
        }
    }
}
