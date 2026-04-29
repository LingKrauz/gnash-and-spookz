using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 12/03/2021 12:00pm MDT
public class AirAttack : MonoBehaviour
{
    public Animator airAAnim;
    public bool airAttackOn;
    public Player_Jump isPGrounded;

    public GameObject lFistCollider;
    public GameObject rFistCollider;
    private AudioController audioCue;

    void Start()
    {
        airAAnim = GetComponent<Animator>();
        airAAnim.SetBool("AirAttackOn", false);
        audioCue = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0) && isPGrounded.GetComponent<Player_Jump>().isGrounded == false)
        //{
        //    AirAttackOn();
        //}
    }

    public void AirAttackOn()
    {
        airAAnim.SetBool("AirAttackOn", true);
        lFistCollider.GetComponent<SphereCollider>().enabled = true;
        rFistCollider.GetComponent<SphereCollider>().enabled = true;

        airAttackOn = gameObject.GetComponent<Animator>().GetBool("AirAttackOn") == true;
        audioCue.PlayAirAttack();
    }

    public void AirAttackOff()
    {
        lFistCollider.GetComponent<SphereCollider>().enabled = false;
        rFistCollider.GetComponent<SphereCollider>().enabled = false;

        airAttackOn = gameObject.GetComponent<Animator>().GetBool("AirAttackOn") == false;
        airAAnim.SetBool("AirAttackOn", false);
    }
}
