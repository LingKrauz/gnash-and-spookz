using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Created by Mitchell Kraus 12/5/21

public class ShootAbility : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;
    public GameObject fireBallUI;
    public Image shootImage;
    public float delayTime;
    private float time;
    public bool isShootActive = false;
    private AudioController soundController;
    public enum abilityState { Shoot, Idle };
    public abilityState currentState;

    void Start()
    {
        time = delayTime;
        shootImage.fillAmount = 1.0f / delayTime;
        currentState = abilityState.Idle;
        soundController = GameObject.Find("AudioSource").GetComponent<AudioController>();

        if (PlayerPrefs.GetInt("FireBallAbility") == 1)
        {
            fireBallUI.SetActive(true);
        }

        else
        {
            fireBallUI.SetActive(false);
        }
    }

    void Update()
    {
        if(time < delayTime)
        {
            time += Time.deltaTime;
        }

        if(PlayerPrefs.GetInt("FireBallAbility") == 1)
        {
            fireBallUI.SetActive(true);

            if ((Input.GetButton("Shoot") || (Input.GetAxis("Shoot") > 0.25)) && currentState == abilityState.Idle && PlayerMovement.canMove)
            {
                //Debug.Log("Keycode and currentstateidle passed");
                if (time >= delayTime)
                {
                    currentState = abilityState.Shoot;
                    //Debug.Log("time>=delayTime test passed");
                }
            }
        }

        else
        {
            fireBallUI.SetActive(false);
        }

        shootImage.fillAmount += 1.0f / delayTime * Time.deltaTime;

        switch (currentState)
        {
            case abilityState.Shoot:
                Shoot();
                isShootActive = true;
                break;
        }
    }
    public void Shoot()
    {
        //Debug.Log("Shoot() activated");
        if (isShootActive)
        {
            //Debug.Log("isShootActive passed");
            Instantiate(projectile.transform, spawnPoint.position, spawnPoint.rotation.normalized);
            projectile.transform.position = spawnPoint.transform.position;
            projectile.transform.rotation = spawnPoint.transform.rotation;
            soundController.PlayShooting();
            time = 0f;
            shootImage.fillAmount = 0f;
            currentState = abilityState.Idle;
            isShootActive = false;
        }
    }

    public void AbilityReset()
    {
        time = 0f;
        shootImage.fillAmount = 0f;
    }
}
