using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreepyWinCondition : MonoBehaviour
{
    public GameObject winText;
    void Start()
    {
        winText.SetActive(false);
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerMovement>().enabled = false;
            winText.SetActive(true);
            StartCoroutine(WinCondition());
        }
    }

    IEnumerator WinCondition()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(0);
    }
}
