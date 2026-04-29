using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTutorial : MonoBehaviour
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
        if(other.tag == "Player")
        {
            dailogueBox.SetActive(true);
            dScript.DisplayDialog("Welcome to CoocooCorsair Cove! Press F to shoot a fireball and blow up any Red Barrel you see! Also, defeat all the normal enemies to unlock the cages to collect all the portrait pieces in order to win!");
            Destroy(gameObject);
        }
    }
}
