using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public CollectableMenuUI objUI;
    private bool hasWon;
    public GameObject winUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            winUI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objUI.backyardCurrentPortraitCount == 4)
            {
                hasWon = true;
            }
        }
    }

    public void LoadMainMenu()
    {
        PlayerPrefs.SetString("CurrLevelName", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(7);
    }
}
