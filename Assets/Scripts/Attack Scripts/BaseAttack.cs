using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 12/03/2021 1:00am MDT
public class BaseAttack : MonoBehaviour
{
    public Animator baseAnim;
    public bool baseAttackOn;
    public Player_Jump isPGrounded;
    public PlayerMovement isPMoving;

    public GameObject lFistCollider;
    public GameObject rFistCollider;
    private AudioController audioCue;

    void Start()
    {
        baseAnim = GetComponent<Animator>();
        baseAnim.SetBool("BaseAttackOn", false);

        lFistCollider.GetComponent<SphereCollider>().enabled = false;
        rFistCollider.GetComponent<SphereCollider>().enabled = false;
        audioCue = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    AttackOkay();
        //}
    }

    public void BaseAttackOn()
    {
        isPMoving.enabled = false;
        audioCue.PlayPunch();
        lFistCollider.GetComponent<SphereCollider>().enabled = true;
        rFistCollider.GetComponent<SphereCollider>().enabled = true;

        baseAttackOn = gameObject.GetComponent<Animator>().GetBool("BaseAttackOn") == true;
        baseAnim.SetBool("BaseAttackOn", true);
    }

    public void BaseAttackOff()
    {
        isPMoving.enabled = true;

        lFistCollider.GetComponent<SphereCollider>().enabled = false;
        rFistCollider.GetComponent<SphereCollider>().enabled = false;

        baseAttackOn = gameObject.GetComponent<Animator>().GetBool("BaseAttackOn") == false;
        baseAnim.SetBool("BaseAttackOn", false);
    }

    //Makes sure the player is NOT moving in any direction nor in the air (jumping) to enable the base attack animation
    public void AttackOkay()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isPGrounded.GetComponent<Player_Jump>().isGrounded == true)
            {
                BaseAttackOn();
            }
        }
    }
}
