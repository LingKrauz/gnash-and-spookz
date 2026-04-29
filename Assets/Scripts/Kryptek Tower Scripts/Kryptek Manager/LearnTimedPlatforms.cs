using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnTimedPlatforms : MonoBehaviour
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
        if (other.GetComponent<PlayerMovement>() && PlayerPrefs.GetInt("LearnTimedPlatform") == 0)
        {
            dialog.SetActive(true);
            dialogScript.DisplayDialog("See that green button. That is a switch for a timed platform. If you step on that, a platform or multiple will appear for only a set duration of time before the platforms disappear. Try and make it to the other side.");
            PlayerPrefs.SetInt("LearnTimedPlatform", 1);
            Destroy(gameObject);
        }
    }
}
