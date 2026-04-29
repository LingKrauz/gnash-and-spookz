using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolume : MonoBehaviour
{
    
    
    private bool hasWon;
    public GameOverMenu gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!hasWon)
            {
                gameOver.GameOver();
                hasWon = true;
            }
        }
    }
}
