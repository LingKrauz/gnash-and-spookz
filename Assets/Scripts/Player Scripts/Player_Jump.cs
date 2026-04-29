using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script Made BY: James Ostrander
//  
// Script Referense Citations: 
//
// First Person Movement in Unity - FPS Controller - YouTube. (n.d.). Retrieved December 3, 2021, from https://www.youtube.com/watch?v=_QajrabyTJc. 
// Technologies, U. (n.d.). CharacterController.move. Unity. Retrieved December 3, 2021, from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html?_ga=2.51247913.1610728725.1638497853-1360200424.1635538119. 
// Hold jump key to jump higher - youtube. (n.d.). Retrieved December 4, 2021, from https://www.youtube.com/watch?v=j111eKN8sJw. 
//
public class Player_Jump : MonoBehaviour
{
    // CReating a variable to store the player controller.
    CharacterController playerController;

    public AudioSource JumpSFX;

    // This is the transform where the sphere check will spawn.
    public Transform groundCollider;

    // The player's position to manipulate the speed of the player.
    public Vector3 playerVelocity;

    // How high will the player jump?
    public float jumpHeight;

    // How far is the player form the nearest ground collider?
    private float groundDistance = 0.4f;

    public float jumpTime;
    private float jumpTimeCounter;

    // This is the normal gravity setting.
    public float gravityScale = -9.81f;

    // Check if the player is grounded or not.
    public bool isGrounded;

    private bool isJumping;

    // Label to check the collisons parameters.
    public LayerMask groundMask;

    public SpooksParachuting SpooksParachuteScript;
    public GameObject SpooksPachuteObject;
    public bool Jumped;
    public Animator pAnim;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCollider.position, groundDistance, groundMask);


        if (isGrounded && playerVelocity.y < 0)
        {
            // This sets the players velocity to a constant value so that players gravity doesn't increase over time.
            playerVelocity.y = -2f;
            pAnim.SetBool("isFalling", false);
            pAnim.SetBool("isJumping", false);

        }
        else if (!isGrounded && playerVelocity.y < 0)
        {            
            pAnim.SetBool("isFalling", true);
                    
        }


        if (playerController.enabled && PlayerMovement.canMove)
        {

            // isGrounded is set by where the player feet is, how far to check below the player, is the collider labeled as ground or not.


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                // Increase the players velocity by the jumpHeight value.
                isJumping = true;
                pAnim.SetBool("isJumping", true);
                Jumped = true;
                jumpTimeCounter = jumpTime;
                playerVelocity.y = jumpHeight;
                JumpSFX.Play();
            }

            if (Input.GetButton("Jump") && isJumping)
            {
                if (jumpTimeCounter > 0)
                {

                    playerVelocity.y = jumpHeight;
                    jumpTimeCounter -= Time.deltaTime;
                }

                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = false;
            }

            // This runs the gravity for the player at all times.

        }
        
        if (playerController.enabled == true)
        {
            playerVelocity.y += gravityScale * Time.deltaTime;
            playerController.Move(playerVelocity * Time.deltaTime);
        }



    }
    
   
   
}
