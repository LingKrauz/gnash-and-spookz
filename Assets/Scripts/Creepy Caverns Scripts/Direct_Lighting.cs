using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direct_Lighting : MonoBehaviour
{
    public GameObject directionalLighting;
    public GameObject valve;
    void Start()
    {
        directionalLighting.SetActive(true);
        valve.SetActive(false);
        RenderSettings.fog = false;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            directionalLighting.SetActive(false);
            valve.SetActive(true);
            RenderSettings.fog = true;
        }
    }
}
