using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 12/12/2021 8:25pm MDT
public class SpikePit : MonoBehaviour
{
    public float spikePitDamage;
    public GameObject playerAvatar;
    public AudioSource spikePlayer;
    public AudioClip spikeSFX;

    void Start()
    {
        spikePlayer = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpikePitDamage();
        }
    }

    public void SpikePitDamage()
    {
        playerAvatar.GetComponent<PlayerHealth>().DamageHealth(spikePitDamage);
        spikePlayer.clip = spikeSFX;
        spikePlayer.Play();
    }
}
