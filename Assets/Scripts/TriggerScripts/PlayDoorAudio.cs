using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorAudio : MonoBehaviour
{
    public void PlayDoorSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}