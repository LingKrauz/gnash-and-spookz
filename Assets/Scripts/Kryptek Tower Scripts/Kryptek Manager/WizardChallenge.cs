using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardChallenge : MonoBehaviour
{
    public GameObject reward;
    public GameObject cutsceneCamera;
    public Text wizardCounterTxt;
    public int counter;

    public Wizard_Enemy[] wizards;

    void Start()
    {
        counter = 0;
        cutsceneCamera.SetActive(false);
    }

    
    void Update()
    {
        wizardCounterTxt.text = "Wizards Defeated: " + counter.ToString() + " / " + wizards.Length.ToString();

        if(counter >= wizards.Length)
        {
            if(PlayerPrefs.GetInt("KryptekChallange") == 0)
            {
                wizardCounterTxt.color = Color.green;
                reward.SetActive(false);
                StartCoroutine(Reward());
                PlayerPrefs.SetInt("KryptekChallange", 1);
            }
        }
    }

    public IEnumerator Reward()
    {
        cutsceneCamera.SetActive(true);
        PlayerMovement.canMove = false;

        yield return new WaitForSeconds(3f);

        cutsceneCamera.SetActive(false);
        PlayerMovement.canMove = true;
    }
}
