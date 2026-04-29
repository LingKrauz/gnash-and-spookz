using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSprintDialog : MonoBehaviour
{
    public DialogScript dialogScript;
    public string dialogToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SprintDialogTrigger"))
        {
            if (PlayerPrefs.GetInt("SprintDialogTrigger") > 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogScript.DisplayDialog(dialogToDisplay);
            PlayerPrefs.GetInt("SprintDialogTrigger", 1);
            gameObject.SetActive(false);

        }
    }
}
