using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_Swing : MonoBehaviour
{
    public Player_Jump jumpScript;

    public bool isSwinging = false;
    
    public Transform playerRef = null;

    void FixedUpdate()
    {
        if (isSwinging)
        {
            playerRef.position = transform.position;
            //playerRef.position = pointContact;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isSwinging)
        {
            isSwinging = false;
            transform.DetachChildren();
            playerRef.GetComponent<Player_Jump>().playerVelocity.x = 10f;
            playerRef.GetComponent<Player_Jump>().gravityScale = -9.81f;
            playerRef.GetComponent<Player_Jump>().playerVelocity.x = 0f;
            playerRef = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerRef = other.transform;
            playerRef.gameObject.transform.SetParent(gameObject.transform);
            playerRef.GetComponent<Player_Jump>().playerVelocity.y = 0f;
            playerRef.GetComponent<Player_Jump>().gravityScale = 0f;
            isSwinging = true;
        }
    }
}
