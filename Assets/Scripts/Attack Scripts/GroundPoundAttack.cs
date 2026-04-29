using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 5:30am MDT
public class GroundPoundAttack : MonoBehaviour
{
    public Player_Jump isPGrounded;

    public GameObject gPACollider;
  
    public float gravity = 0f;
    Vector3 velocity;
    private CharacterController cController;
    private AudioController audioCue;
    

    void Start()
    {
        cController = GetComponent<CharacterController>();
        gPACollider.GetComponent<SphereCollider>().enabled = false;
        audioCue = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    void Update()
    {
        if (isPGrounded.GetComponent<Player_Jump>().isGrounded == false && Input.GetButtonDown("GroundPound") && PlayerMovement.canMove)
        {
            gPACollider.GetComponent<SphereCollider>().enabled = true;

            
            audioCue.PlayGroundPound();
            velocity.y = gravity;
            cController.Move(velocity);
            
        }
        else if (isPGrounded.GetComponent<Player_Jump>().isGrounded == true)
        {
            gPACollider.GetComponent<SphereCollider>().enabled = false;
        }

        
    }
}
