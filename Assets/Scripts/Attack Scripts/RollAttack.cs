using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Yaimee N. Martinez Molina 12/04/2021 5:07am MDT
public class RollAttack : MonoBehaviour
{
    public Player_Jump isPGrounded;
    public GameObject hideRoll;
    private AudioController audioCue;
    private bool isAudioPlaying;

    void Start()
    {
        hideRoll.SetActive(false);
        audioCue = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    void Update()
    {
        RollAttackOkay();
    }

    public void RollAttackOkay()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetButton("Roll") && isPGrounded.GetComponent<Player_Jump>().isGrounded == true && PlayerMovement.canMove)
            {
                RollAttacking();
            }
            else
            {
                NotRollAttacking();
            }
        }
        else
        {
            NotRollAttacking();
        }

    }

    public void RollAttacking()
    {
        if(!isAudioPlaying)
        {
            audioCue.PlayRollAttack();
            isAudioPlaying = true;
        }
        hideRoll.SetActive(true);
    }

    public void NotRollAttacking()
    {
        if(isAudioPlaying)
        { 
            isAudioPlaying = false;
            audioCue.StopRollAttack();
        }
        hideRoll.SetActive(false);
    }
}
