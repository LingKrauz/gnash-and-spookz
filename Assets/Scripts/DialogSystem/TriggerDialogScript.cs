using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogScript : MonoBehaviour
{
    public DialogScript dialogScript;
    public string dialogTextToDisplay;
    private bool hasEnteredTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !hasEnteredTrigger)
        {
            PlayerMovement.canMove = false;
            dialogScript.DisplayDialog(dialogTextToDisplay);
            hasEnteredTrigger = true;
            PlayerPrefs.SetInt("HubLevelTutorial", 1);
        }
    }
}
