using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//How to create a save slot system using ... - youtube.com. (n.d.). September 30, 2021, from https://www.youtube.com/watch?v=ty6aPQNj0Ds. 
public class SceneSwitchButtons : MonoBehaviour
{
    public void QuitGame()
    {   //Keeps player data from save ID
        PlayerPrefs.SetInt("Save" + SaveID.saveData, 1);
        //References load data from save ID
        PlayerPrefs.SetInt("Load" + SaveID.saveData, 1);
        //References and saves current Scene to save ID
        PlayerPrefs.SetInt("SavedScene" + SaveID.saveData, SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetString("CurrLevelname", SceneManager.GetActiveScene().name);
        //Returns the player back to the main menu.
        SceneManager.LoadScene(0);
    }

}
