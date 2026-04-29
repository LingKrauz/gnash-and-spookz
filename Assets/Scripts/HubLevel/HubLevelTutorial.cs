using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubLevelTutorial : MonoBehaviour
{
    public DialogScript dialogScript;
    public string dialogTextToDisplay;
    private static bool hasEnteredTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasEnteredTrigger)
        { 
            if (PlayerPrefs.GetInt("HubLevelTutorial") == 0)
            {
                PlayerMovement.canMove = false;
                dialogScript.DisplayDialog(dialogTextToDisplay);
                hasEnteredTrigger = true;
                PlayerPrefs.SetInt("HubLevelTutorial", 1);
            }
        }
    }
}
