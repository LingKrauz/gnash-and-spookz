using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait_Intro : MonoBehaviour
{
    public GameObject dailogueBox;
    public DialogScript dScript;
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
        if (other.tag == "Player")
        {
            
            
            dailogueBox.SetActive(true);
            dScript.DisplayDialog("Press Alt to submit a portrait piece ");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            
        }
    }
}
