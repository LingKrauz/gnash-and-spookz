using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 12/15/2021 6:23pm MDT
//Redoing script. Original was deleted.
public class MaxHealthPickup : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private float newMaxHealth = 2;
    public CollectibleUI collectible;
    public bool isPlayerHealed;

    void Start()
    {
        playerHealth = GameObject.Find("PlayerAvatar").GetComponent<PlayerHealth>();

        collectible = GameObject.Find("HUD").GetComponent<CollectibleUI>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth.GetComponent<PlayerHealth>().maxHealth = playerHealth.GetComponent<PlayerHealth>().maxHealth + newMaxHealth;
            
            collectible.SetMaxHealthTxtActive();

            isPlayerHealed = true;
            //This will force the healthbar to update properly to show full health, otherwise it will look like the player is not fully healed.
            playerHealth.GetComponent<PlayerHealth>().DamageHealth(playerHealth.GetComponent<PlayerHealth>().maxHealth * -1);
        }

        if (isPlayerHealed == true)
        {
            playerHealth.GetComponent<PlayerHealth>().DamageHealth(newMaxHealth * -1);
            isPlayerHealed = false;
        }
    }
}
