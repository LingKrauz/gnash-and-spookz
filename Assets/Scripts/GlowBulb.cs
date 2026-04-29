using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBulb : MonoBehaviour
{
    public GameObject GreenBulb;
    public GameObject RedBulb;
    public VineRemoval VRem;


    // Update is called once per frame
    void Update()
    {
        if (GreenBulb.activeSelf)
        {
            RedBulb.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerAttack>())
        {
            if(!GreenBulb.activeSelf)
            {
                VRem.counter++;
                GreenBulb.SetActive(true);
            }

            
        }
    }
}
