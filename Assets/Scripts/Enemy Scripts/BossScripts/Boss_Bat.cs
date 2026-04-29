using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bat : MonoBehaviour
{
    public Bat_Enemy batScript;
    private void Update()
    {
        batScript.isChasing = true;
        batScript.playerRef = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
