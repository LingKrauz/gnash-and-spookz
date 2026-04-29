using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Gate : MonoBehaviour
{
    Animator openAnim;

    public GameObject doorText;
    void Start()
    {
        openAnim = GetComponentInParent<Animator>();
        doorText.SetActive(true);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            openAnim.SetBool("isOpen", true);
            transform.GetComponent<Collider>().enabled = false;
            doorText.SetActive(false);
        }
    }
}
