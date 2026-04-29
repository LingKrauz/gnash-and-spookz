using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutsceneCam : MonoBehaviour
{
    public GameObject cam;
    public GameObject trigger;
    public Animator anim;
    private bool isAnimPlaying;

    void Start()
    {
        if (cam != null)
        {
            cam.SetActive(false);
        }

        if (PlayerPrefs.GetInt("KryptekTrigger") > 0 && anim != null)
        {
            anim.SetBool("isOpen", true);
        }

      

    }

    void Update()
    {
        if (isAnimPlaying)
        {
            PlayerMovement.canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cam != null)
            {
                isAnimPlaying = true;
                cam.SetActive(true);
            }
        }
        if (anim != null)
        {
            anim.SetBool("isOpen", true);
        }
    }

    public void TurnOffCam()
    {
        isAnimPlaying = false;
        PlayerMovement.canMove = true;
        gameObject.SetActive(false);
        trigger.SetActive(false);
    }
}
