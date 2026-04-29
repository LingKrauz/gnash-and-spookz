using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deploy_Decoy : MonoBehaviour
{
    public GameObject decoyPrefab;
    public GameObject decoySelf;
    public GameObject decoyUI;
    public Image decoyImage;
    public bool decoyExists;
    private Transform spawn;
    private Player_Jump jumpCheck;
    public bool isActive;

    public float rateTime;
    private float timer;


    void Start()
    {
        timer = rateTime;
        decoyImage.fillAmount = 1.0f / rateTime;
        decoySelf = null;
        jumpCheck = GetComponentInParent<Player_Jump>();
        spawn = this.transform;
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("DecoyAbility") == 1)
        {
            isActive = true;
            decoyUI.SetActive(true);
        }

        else
        {
            isActive = false;
            decoyUI.SetActive(false);
        }

        if(timer < rateTime)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetButtonDown("Decoy") && jumpCheck.isGrounded == true && isActive)
        {
            if(timer >= rateTime)
            {
                if (decoyExists)
                {
                    Destroy(decoySelf);
                    decoyExists = false;
                    SetDecoy();
                }

                else
                {
                    SetDecoy();
                }
            }
        }

        decoyImage.fillAmount += 1.0f / rateTime * Time.deltaTime;
    }

    public void SetDecoy()
    {
        timer = 0f;
        decoyImage.fillAmount = 0f;
        decoyExists = true;
        GameObject clone = Instantiate(decoyPrefab, spawn);
        clone.transform.position = spawn.position;
        spawn.transform.DetachChildren();

        decoySelf = clone;
    }

    public void AbilityReset()
    {
        timer = 0f;
        decoyImage.fillAmount = 0f;
    }
}
