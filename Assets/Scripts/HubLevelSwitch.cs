using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubLevelSwitch : MonoBehaviour
{
    [SerializeField]
    private int SceneNumber;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
