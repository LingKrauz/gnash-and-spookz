using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour
{
    private float timer;
    private float timerSet = .25f;
    public bool isDamaging;
    private GameObject player;
    private bool isInTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = timerSet;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaging && isInTrigger)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                player.GetComponent<PlayerHealth>().DamageHealth(1);
                timer = timerSet;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player = null;
            isInTrigger = false;
        }
    }


}
