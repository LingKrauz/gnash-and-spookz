using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonAudio : MonoBehaviour
{
    public AudioClip acceptAudio;
    public AudioClip backAudio;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayAcceptAudio()
    {
        audioPlayer.Stop();
        audioPlayer.clip = acceptAudio;
        audioPlayer.Play();
    }

    public void PlayBackAudio()
    {
        audioPlayer.Stop();
        audioPlayer.clip = backAudio;
        audioPlayer.Play();
    }


}
