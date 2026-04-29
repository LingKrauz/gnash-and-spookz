using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrap : MonoBehaviour
{
    public Transform teleportLoc;
    public GameObject player;
    public PlayerHealth pHealth;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.canMove = false;
            player.GetComponent<CharacterController>().enabled = false;
            pHealth.DamageHealth(1);
            player.transform.position = teleportLoc.position;
            player.GetComponent<CharacterController>().enabled = true;
            PlayerMovement.canMove = true;
        }
    }

}
