using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhead : MonoBehaviour
{
    public float attackTime;
    private float timer;

    public bool isOverhead;

    Animator anim;

    EliteGuard_Enemy eliteGuard;

    void Start()
    {
        timer = attackTime;

        anim = GetComponentInParent<Animator>();
        eliteGuard = GetComponentInParent<EliteGuard_Enemy>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            isOverhead = true;

            timer += Time.deltaTime;

            if(timer >= attackTime && !eliteGuard.hasNoShield)
            {
                anim.SetTrigger("OverheadAttack");
                anim.SetBool("isGuarding", false);
                anim.SetBool("isBlocking", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true);
                timer = 0f;
            }

            else if (timer >= attackTime && eliteGuard.hasNoShield)
            {
                anim.SetTrigger("OverheadAttack");
                anim.SetBool("isGuarding", false);
                anim.SetBool("isBlocking", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true);
                anim.SetBool("isNoShield", true);
                timer = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0f;
        isOverhead = false;
        anim.SetBool("isGuarding", false);
        anim.SetBool("isBlocking", true);
    }
}
