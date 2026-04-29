using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAbilities : MonoBehaviour
{
    static SpinAttack spinAttack;
    static ShootAbility shoot;
    static SpooksBubbleShield shield;
    static DashScript dash;
    static Deploy_Decoy decoy;

    void Start()
    {
        spinAttack = FindObjectOfType<SpinAttack>();
        shoot = FindObjectOfType<ShootAbility>();
        shield = FindObjectOfType<SpooksBubbleShield>();
        dash = FindObjectOfType<DashScript>();
        decoy = FindObjectOfType<Deploy_Decoy>();
    }

    public static void ResetAbility()
    {
        spinAttack.AbilityReset();
        shoot.AbilityReset();
        shield.AbilityReset();
        dash.AbilityReset();
        decoy.AbilityReset();
    }
}
