using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 9:00am MDT
public class HealthPickup : MonoBehaviour
{
    public PlayerHealth playerHeal;

    //Heal amount in inspector should be a NEGATIVE number in order to heal the player
    public float healAmount;

    private void Start()
    {
        playerHeal = GameObject.Find("PlayerAvatar").GetComponent<PlayerHealth>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealPlayer();
        }
    }

    public void HealPlayer()
    {
        playerHeal.GetComponent<PlayerHealth>().DamageHealth(healAmount);
    }
}
