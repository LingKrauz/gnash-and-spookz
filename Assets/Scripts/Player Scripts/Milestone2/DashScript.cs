using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashScript : MonoBehaviour
{
    private CharacterController controller;
    private GameObject player;
    public GameObject dashUI;
    public Image dashImage;
    public float timerSet;
    private float timer;
    private bool isDashing;
    private int frameCount = 30;
    private int framesDone;
    private float newPos;
    public GameObject dashOBJ;
    public AudioController audioCon;
    public Animator pAnim;

    void Start()
    {
        timer = timerSet;
        dashImage.fillAmount = 1.0f / timerSet;
        player = gameObject;
        controller = player.GetComponent<CharacterController>();
        dashOBJ.SetActive(false);

        if (PlayerPrefs.GetInt("DashAbility") == 1)
        {
            dashUI.SetActive(true);
        }

        else
        {
            dashUI.SetActive(false);
        }
    }

    void Update()
    {
        if(!isDashing && PlayerMovement.canMove)
        {
            if(timer < timerSet)
            {
                timer += Time.deltaTime;
            }

            if(timer >= timerSet)
            {
                if (PlayerPrefs.GetInt("DashAbility") == 1)
                {
                    dashUI.SetActive(true);

                    if (Input.GetButtonDown("Dash") && player.GetComponent<Player_Jump>().isGrounded)
                    {
                        Dash();
                        timer = 0f;
                        dashImage.fillAmount = 0f;
                    }
                }

                else
                {
                    dashUI.SetActive(false);
                }
            }
        }

        dashImage.fillAmount += 1.0f / timerSet * Time.deltaTime;

        if (isDashing)
        {
            newPos = (float)framesDone / frameCount;

            
            if(framesDone >= frameCount)
            {
                isDashing = false;
                pAnim.SetBool("isDashing", false);
                dashOBJ.SetActive(false);
                player.GetComponent<PlayerMovement>().isDashing = isDashing;
                framesDone = 0;
                //controller.enabled = true;
            }
            
            controller.Move(player.transform.forward * .25f);
            //player.transform.position = Vector3.Lerp(player.transform.position, (player.transform.position + (player.transform.forward * 2f)), newPos);

            framesDone++;

            /*if (newPos <= 0)
            {
                isDashing = false;
                controller.enabled = true;
            }*/
            
        }
    }

    public void Dash()
    {
        //controller.enabled = false;
        isDashing = true;
        audioCon.PlayDash();
        dashOBJ.SetActive(true);
        player.GetComponent<PlayerMovement>().isDashing = isDashing;
        pAnim.SetBool("isDashing", true);
    }

    public void AbilityReset()
    {
        timer = 0f;
        dashImage.fillAmount = 0f;
    }
}
