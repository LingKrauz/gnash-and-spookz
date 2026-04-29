using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 7:34am MDT
public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    int playerDamage;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<Enemy>().TakeDamage(playerDamage);
        }
        
        if (other.GetComponent<Bat_Enemy>() != null)
        {
            other.GetComponent<Bat_Enemy>().TakeDamage(playerDamage);
        }

        if(other.GetComponent<Decoy>() != null)
        {
            other.GetComponent<Decoy>().TakeDamage(playerDamage);
        }

        if (other.name == "Castle")
        {
            Destroy(other.gameObject);
        }
    }
}
