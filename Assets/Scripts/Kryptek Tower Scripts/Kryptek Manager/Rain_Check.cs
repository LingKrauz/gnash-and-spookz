using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Check : MonoBehaviour
{
    public GameObject rainEffect;

    public AudioSource indoorSFX;
    public AudioSource outdoorSFX;

    public bool isRaining;

    void Start()
    {
        
    }

    
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (isRaining)
            {
                rainEffect.SetActive(true);
                indoorSFX.Stop();
                outdoorSFX.Play();
            }

            if (!isRaining)
            {
                rainEffect.SetActive(false);

                outdoorSFX.Stop();
                indoorSFX.Play();
            }
        }
    }
}
