using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnDashAbility : MonoBehaviour
{
    public DialogScript dialogScript;
    public string dialogTextToDisplay;

    void Start()
    {
        dialogScript = FindObjectOfType<DialogScript>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.canMove = false;
            dialogScript.DisplayDialog(dialogTextToDisplay);
            PlayerPrefs.SetInt("DashAbility", 1);
        }
    }
}
