using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LearnDecoyAbility : MonoBehaviour
{
    public DialogScript dialogScript;
    public GameObject dialog;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && PlayerPrefs.GetInt("DecoyAbility") == 0)
        {
            dialog.SetActive(true);
            dialogScript.DisplayDialog("These enemies look easy. Let's try and take them out from behind. Press the (X) key and depoly your clone. This will distract enmies so we can hit them from the back. Be warned that Elite Guards and Wizards won't fall for this trick!");
            PlayerPrefs.SetInt("DecoyAbility", 1);
            Destroy(gameObject);
        }
    }
}
