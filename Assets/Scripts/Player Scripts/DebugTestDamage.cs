using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestDamage : MonoBehaviour
{
    public PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.DamageHealth(-1);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.DamageHealth(1);
        }
    }
}
