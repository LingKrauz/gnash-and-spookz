using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Spawn : MonoBehaviour
{

    public GameObject boulderPrefab;

    public Transform spawn1Pos;
    public Transform spawn2Pos;

    Vector3 spawn1Vec;
    Vector3 spawn2Vec;

    public float spawn1Time;
    public float spawn2Time;
    private float spawn1Timer;
    private float spawn2Timer;

    private bool isActive;

    void Start()
    {
        spawn1Timer = 0f;
        spawn2Timer = 0f;

        spawn1Vec = spawn1Pos.position;
        spawn2Vec = spawn2Pos.position;
    }

    
    void Update()
    {
        if (isActive)
        {
            spawn1Timer += Time.deltaTime;
            spawn2Timer += Time.deltaTime;

            if (spawn1Timer >= spawn1Time)
            {
                GameObject obj = Instantiate(boulderPrefab, spawn1Vec, Quaternion.identity);
                spawn1Timer = 0f;

                Destroy(obj, 8f);
            }

            if(spawn2Timer >= spawn2Time)
            {
                GameObject obj = Instantiate(boulderPrefab, spawn2Vec, Quaternion.identity);
                spawn2Timer = 0f;

                Destroy(obj, 8f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && !isActive)
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && isActive)
        {
            isActive = false;

            spawn1Timer = 0f;
            spawn2Timer = 0f;
        }
    }
}
