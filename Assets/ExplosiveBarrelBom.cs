using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelBom : MonoBehaviour
{
    public bool isExploded;
    public GameObject Barrel;
    public GameObject vFX;
    public AudioSource ASource;
    public AudioClip AClip;

    // Start is called before the first frame update
    void Start()
    {
    

        Barrel.SetActive(true);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ProjectileScript>())
        {   
            isExploded = true;
            ASource.PlayOneShot(AClip);
            Explosion();
            
        }
    }
    public void Explosion()
    {
        if (isExploded == true)
        {
            vFX.SetActive(true);
            Barrel.SetActive(false);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

   




}
