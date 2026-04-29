using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    private float timer;
    private float timerSet = 1f;
    private float damage = 1f;
    private bool isDamaging;
    private PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerAvatar").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDamaging)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                player.DamageHealth(damage);
                timer = timerSet;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDamaging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDamaging = false;
            timer = timerSet;
        }
    }

}
