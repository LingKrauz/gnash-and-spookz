using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubDialogCheck : MonoBehaviour
{
    public string name;

    void Start()
    {
        name = gameObject.name;

        if(PlayerPrefs.GetInt(name) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            PlayerPrefs.SetInt(name, 1);
        }
    }
}
