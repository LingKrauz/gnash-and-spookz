using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewLevelTrigger : MonoBehaviour
{
    public TextMeshPro levelText;
    public string levelName;
    public string LevelSceneName;

    void Start()
    {
        if (levelName != "")
        {
            levelText.text = levelName;
        }
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetString("CurrLevelName", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(LevelSceneName);
        }
    }
}
