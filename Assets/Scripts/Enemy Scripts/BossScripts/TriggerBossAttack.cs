using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossAttack : MonoBehaviour
{
    public BossScript bScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (bScript != null)
        {
            bScript.ShootProjectile();
        }

    }

    public void Spawn()
    {
        if (bScript != null)
        {
            bScript.SpawnEnemy();
        }
    }


}
