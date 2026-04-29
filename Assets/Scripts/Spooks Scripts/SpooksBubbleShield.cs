using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpooksBubbleShield : MonoBehaviour
{
    public GameObject spooksShield;
    public GameObject shieldUI;
    public Image shieldImage;
    public AudioSource sSource;
    public AudioClip spooksClip;
    public float shieldCooldown;
    private float shieldTimer;

    void Start()
    {
        shieldTimer = shieldCooldown;
        shieldImage.fillAmount = 1.0f / shieldCooldown;
        spooksShield.SetActive(false);

        if (PlayerPrefs.GetInt("ShieldAbility") == 1)
        {
            shieldUI.SetActive(true);
        }

        else
        {
            shieldUI.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerMovement.canMove)
        {
            if(PlayerPrefs.GetInt("ShieldAbility") == 1)
            {
                shieldUI.SetActive(true);
                SpooksShieldActivate();
            }

            else
            {
                shieldUI.SetActive(false);
            }

            if(shieldTimer < shieldCooldown)
            {
                shieldTimer += Time.deltaTime;
            }

            shieldImage.fillAmount += 1.0f / shieldCooldown * Time.deltaTime;
        }
    }

    public void SpooksShieldActivate()
    {
        if ((Input.GetButtonDown("Shield") || Input.GetAxis("Shield") > .25) && shieldTimer >= shieldCooldown)
        {
            shieldTimer = 0f;
            shieldImage.fillAmount = 0f;
            sSource.PlayOneShot(spooksClip);
            spooksShield.gameObject.SetActive(true);
            StartCoroutine(ShieldOff());
        }
    }

    IEnumerator ShieldOff()
    {
        yield return new WaitForSeconds(2f);
        
        spooksShield.SetActive(false);
    }

    public void AbilityReset()
    {
        shieldTimer = 0f;
        shieldImage.fillAmount = 0f;
    }
}
    


