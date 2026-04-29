using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public MazeSwitch mSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDoorSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void ToggleCamOff()
    {
        if (mSwitch != null)
        {
            mSwitch.EndCutscene();
        }
    }
}
