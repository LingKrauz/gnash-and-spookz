using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by Mitchell Kraus 12/13/21

public class SinkingPlatform : MonoBehaviour
{
    bool onPlatform;

    public GameObject platform;

    Vector3 platformPosition;

    Vector3 platformReset;

    [SerializeField]
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //platform = GameObject.Find("SinkingPlatform");
        platformPosition = platform.transform.position;
        platformReset = platform.transform.position;

    }
    //I already tried using Time.DeltaTime by itself and couldn't get it to work, so FixedUpdate() it is
    void FixedUpdate()
    {
        if (onPlatform && platformPosition.y >= 1)
        {
            platformPosition.y -= moveSpeed;
            platform.transform.position = platformPosition;
        }
        else if (!onPlatform && platformPosition.y <= platformReset.y)
        {
            platformPosition.y += moveSpeed;
            platform.transform.position = platformPosition;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlatform = true;
            //Debug.Log("Player stepped on sinkingplatform");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlatform = false;
            //Debug.Log("Player stepped off of sinkingplatform");
        }
    }
}
