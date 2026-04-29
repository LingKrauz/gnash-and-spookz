using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Created by: Yaimee N. Martinez Molina 11/30/2021 6:40am MDT

//Source of code: Jason Weimann. (2020). Third Person Movement in Unity. YouTube. Retrieved November 30, 2021, from https://youtu.be/4HpC--2iowE. 

//Modified 11/30/2021 4:17PM Mountain by Mitchell Kraus
//Referenced code: Brackeys. (2020). THIRD PERSON MOVEMENT in Unity. YouTube. Retrieved November 30, 2021, from https://www.youtube.com/watch?v=4HpC--2iowE

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public static bool canMove = true;

    public CharacterController controller;

    public GameObject bShad;

    public Transform mainCamera;

    public int groundMask;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public bool isDashing;

    public Animator pAnim;

    public Animator sAnim;

    public static bool isIntroAnim;
   

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            isIntroAnim = true;
            
        }
        else
        {
            isIntroAnim = false;
        }
        sAnim.SetBool("doShrink", true);
        canMove = true;
        groundMask = LayerMask.NameToLayer("Ground");
    }
    void Update()
    {
        MovementCheck();
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if(hit.transform.gameObject.layer == groundMask)
            {
                Vector3 shadowpoint = hit.point;
                bShad.transform.position = shadowpoint;
            }
        }


    }
    public void MovementCheck()
    {
        if (canMove)
        {


            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
                       
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
                        
            if (!isIntroAnim)
            {
                pAnim.SetFloat("Velocity", direction.magnitude);
            }

            if (direction.magnitude >= 0.1f && !isDashing)
            {
                //Rotates player to the direction its moving using the Atan2 function
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                //Sets rotation using mouse input *and* camera angle/direction
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 newDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(newDirection.normalized * speed * Time.deltaTime);
                
            }
        }
        else if(!canMove && !isIntroAnim)
        {
            pAnim.SetFloat("Velocity", 0f);
            
        }
        else if (isIntroAnim)
        {
            sAnim.SetBool("doShrink", false);
        }
        
    }
}
