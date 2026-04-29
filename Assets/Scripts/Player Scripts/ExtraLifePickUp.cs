using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 10:57am MDT
public class ExtraLifePickUp : MonoBehaviour
{
    public HealthBar lifeCountHUD;

    private void Start()
    {
        lifeCountHUD = GameObject.Find("HUD").GetComponent<HealthBar>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AddExtraLife();
        }
    }

    public void AddExtraLife()
    {
        PlayerHealth.lives++;
        PlayerPrefs.SetInt("PlayerLives", PlayerPrefs.GetInt("PlayerLives") + 1);
        lifeCountHUD.UpdateLives(PlayerPrefs.GetInt("PlayerLives"));
    }
}
