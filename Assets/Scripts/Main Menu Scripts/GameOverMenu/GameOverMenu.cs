using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOver;
 
    private void Start()
    {
        gameOver.SetActive(false);   
    }
    public void GameOver()
    {
        gameOver.SetActive(true);

    }

    
}
