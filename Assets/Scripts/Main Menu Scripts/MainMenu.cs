using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//How to create a save slot system using ... - youtube.com. (n.d.). Retrieved September 30, 2021, from https://www.youtube.com/watch?v=ty6aPQNj0Ds. 
public class MainMenu : MonoBehaviour
{   //Public array for new game and load game buttons on the Main Menu Canvas

    public AudioSource mButtons;

    public GameObject loadGame1;
    public GameObject loadGame2;
    public GameObject loadGame3;
    public GameObject newGame1;
    public GameObject newGame2;
    public GameObject newGame3;

    //Memory profiles for 3 indiviual save ID's
    public int saveProfile1;
    public int saveProfile2;
    public int saveProfile3;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;   
    }

    private void Update()
    {
        SaveDataCall1();
        SaveDataCall2();
        SaveDataCall3();
    }
    public void SaveDataCall1()
    {
        if (PlayerPrefs.GetInt("Save" + saveProfile1) == 1)
        {
            loadGame1.SetActive(true);
            newGame1.SetActive(false);
        }
        else
        {
            loadGame1.SetActive(false);
            newGame1.SetActive(true);
        }
    }
    public void SaveDataCall2()
    {
        if (PlayerPrefs.GetInt("Save" + saveProfile2) == 1)
        {
            loadGame2.SetActive(true);
            newGame2.SetActive(false);
        }
        else
        {
            loadGame2.SetActive(false);
            newGame2.SetActive(true);
        }
    }
    public void SaveDataCall3()
    {
        if (PlayerPrefs.GetInt("Save" + saveProfile3) == 1)
        {
            loadGame3.SetActive(true);
            newGame3.SetActive(false);
        }
        else
        {
            loadGame3.SetActive(false);
            newGame3.SetActive(true);
        }
    }
    public void NewGame()
    {
        MainMenuSound();
        Cursor.lockState = CursorLockMode.Locked;
        //Loads first scene in build settings when starting a new game
        SceneManager.LoadScene(1);

    }
    public void LoadGame()
    {
        MainMenuSound();
        Cursor.lockState = CursorLockMode.Locked;
        //Refferes to players save ID and loads the player prefs
        if (PlayerPrefs.GetInt("Load"+ SaveID.saveData) == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene" + SaveID.saveData));
        }
    }
    //SaveID's int saveID is being set = to _saveID
    public void SetSaveID(int _saveID)
    {
        SaveID.saveData = _saveID;
    }
    public void ClearSave(int _saveID)
    {
        PlayerPrefs.DeleteKey("Save" + _saveID);
    }

    public void MainMenuSound()
    {
        mButtons.Play();
        StartCoroutine(WaitForMenu());
    }
    IEnumerator WaitForMenu()
    {
        yield return new WaitForSeconds(2f);
       
    }
}
