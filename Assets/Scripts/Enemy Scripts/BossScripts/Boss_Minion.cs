using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Minion : MonoBehaviour
{
    public Enemy enemyScript;
    private GameObject playerObject;
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        enemyScript.playerRef = playerObject.transform;
        enemyScript.isPlayer = true;
    }
}
