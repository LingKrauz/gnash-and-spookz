using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIntro : MonoBehaviour
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
            dScript.DisplayDialog(" CONTROLS: WASD (Movement), Left Joystick on gaming your gaming remote.");
            Destroy(gameObject);
        }
    }
}
