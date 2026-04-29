using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBreathDamage : MonoBehaviour
{
    public PlayerHealth pHealth;
    private bool lostBreath;
    // Start is called before the first frame update
    void Start()
    {
        lostBreath = true;
        StartDrowning();
    }

    public void startDrown()
    {
        lostBreath = true;
    }
    public void cancelDrown()
    {
        lostBreath = false;
    }
    public void StartDrowning()
    {
        StartCoroutine(NoBreathDamaged());
    }
    IEnumerator NoBreathDamaged()
    {

        while (lostBreath == true)
        {
            yield return new WaitForSeconds(2f);
            pHealth.DamageHealth(1f);
        }

    }

}
