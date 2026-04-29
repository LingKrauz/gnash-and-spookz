using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created by: Yaimee N. Martinez Molina 12/12/2021 7:14pm MDT
public class SpinAttack : MonoBehaviour
{
    public Animator pAnim;
    public bool spinAttackOn;
    public GameObject hammer;
    public PlayerAnimController hammerCollider;
    public Player_Jump jump;
    public GameObject spinAttackUI;
    public Image spinAttackImage;

    public float spinRate;
    private float spinTimer;

    void Start()
    {

        //hammerCollider.DisableDamage();
        hammer.SetActive(false);

        if(PlayerPrefs.GetInt("SpinAttackAbility") == 1)
        {
            spinAttackUI.SetActive(true);
        }

        else
        {
            spinAttackUI.SetActive(false);
        }

        spinTimer = spinRate;
        spinAttackImage.fillAmount = 1.0f / spinRate;
    }

    void Update()
    {
        if(spinTimer < spinRate)
        {
            spinTimer += Time.deltaTime;
        }

        if (PlayerPrefs.GetInt("SpinAttackAbility") == 1)
        {
            spinAttackUI.SetActive(true);

            if (Input.GetButtonDown("Attack") && PlayerMovement.canMove && !pAnim.GetBool("doSwing") && spinTimer >= spinRate)
            {
                if (spinTimer >= spinRate)
                {
                    SpinAttacking();
                }
            }
            else if(Input.GetButtonDown("Attack") && PlayerMovement.canMove && pAnim.GetBool("doSwing") && spinTimer >= spinRate)
            {
                hammer.SetActive(false);
                pAnim.SetBool("doSwing", false);
            }
        }

        else
        {
            spinAttackUI.SetActive(false);
        }

        spinAttackImage.fillAmount += 1.0f / spinRate * Time.deltaTime;
    }

    public void SpinAttacking()
    {
       
        hammer.SetActive(true);
        
        pAnim.SetBool("doSwing", true);

        spinTimer = 0f;
        spinAttackImage.fillAmount = 0f;
        

    }

    

    public void AbilityReset()
    {
        spinTimer = 0f;
        spinAttackImage.fillAmount = 0f;
    }
}
