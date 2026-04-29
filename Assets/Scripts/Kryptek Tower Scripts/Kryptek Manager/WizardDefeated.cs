using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDefeated : MonoBehaviour
{
    WizardChallenge wizardChallenge;
    Wizard_Enemy wizard;

    bool isDead;

    void Start()
    {
        wizardChallenge = FindObjectOfType<WizardChallenge>();
        wizard = GetComponent<Wizard_Enemy>();
    }

    
    void Update()
    {
        if (!isDead)
        {
            if (wizard.health <= 0)
            {
                isDead = true;
                wizardChallenge.counter++;
            }
        }
    }
}
