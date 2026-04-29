using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverToMenu : MonoBehaviour
{
    private void GOReturnToMenu()
    {

        PlayerPrefs.SetInt("Save" + SaveID.saveData, 1);
        PlayerPrefs.SetInt("Load" + SaveID.saveData, 1);
        PlayerPrefs.SetInt("SavedScene" + SaveID.saveData, SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
