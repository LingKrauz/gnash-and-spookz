using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TestMainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject backButton;
    public GameObject levelsButton;
    public AudioMixer mixer;
    public GameObject optionsUI;
    public GameObject menuButtons;
    public GameObject levelListButton;
    private bool isInOptions;
    private bool isInLevels;
    public GameObject[] sliders;

    void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EventSystem.current.SetSelectedGameObject(playButton);
        optionsUI.SetActive(false);
        levelListButton.SetActive(false);
        if (PlayerPrefs.HasKey("MasterMixer"))
        {
            mixer.SetFloat("Master", Mathf.Log(PlayerPrefs.GetFloat("MasterMixer")) * 20);
        }
        else
        {
            mixer.SetFloat("Master", Mathf.Log(.5f) * 20);
        }
        if (PlayerPrefs.HasKey("MusicMixer"))
        {
            mixer.SetFloat("Music", Mathf.Log(PlayerPrefs.GetFloat("MusicMixer")) * 20);
        }
        else
        {
            mixer.SetFloat("Music", Mathf.Log(.5f) * 20);
        }
        if (PlayerPrefs.HasKey("SFXMixer"))
        {
            mixer.SetFloat("SFX", Mathf.Log(PlayerPrefs.GetFloat("SFXMixer")) * 20);
        }
        else
        {
            mixer.SetFloat("SFX", Mathf.Log(.5f) * 20);
        }

    }
    

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && isInLevels)
        {
            CloseLevelList();
        }
        else if (Input.GetButtonDown("Cancel") && isInOptions)
        {
            CloseOptions();
        }

        if (EventSystem.current.currentSelectedGameObject == null && Input.anyKeyDown && !isInOptions && !isInLevels)
        {
            EventSystem.current.SetSelectedGameObject(playButton);
        }
        else if (EventSystem.current.currentSelectedGameObject == null && Input.anyKeyDown && isInOptions)
        {
            EventSystem.current.SetSelectedGameObject(backButton);
        }
        else if (EventSystem.current.currentSelectedGameObject == null && Input.anyKeyDown && isInLevels)
        {
            EventSystem.current.SetSelectedGameObject(levelsButton);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void PlayButton()
    {

        if (PlayerPrefs.HasKey("CurrLevelName"))
        {
            if (PlayerPrefs.GetString("CurrLevelName") != "")
            {
                SceneManager.LoadScene(PlayerPrefs.GetString("CurrLevelName"));
            }
            else
            {
                SceneManager.LoadScene(10);
            }
        }
        else
        {
            SceneManager.LoadScene(10);
        }

    }
    public void OpenOptions()
    {
        optionsUI.SetActive(true);
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].GetComponent<VolumeController>().ResetSlider();
        }
        menuButtons.SetActive(false);
        isInOptions = true;
        EventSystem.current.SetSelectedGameObject(backButton);
        
    }

    public void CloseOptions()
    {
        menuButtons.SetActive(true);
        optionsUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton);
        isInOptions = false;
    }

    public void OpenLevelList()
    {
        menuButtons.SetActive(false);
        levelListButton.SetActive(true);
        isInLevels = true;
        EventSystem.current.SetSelectedGameObject(levelsButton);
    }

    public void CloseLevelList()
    {
        Time.timeScale = 1f;
        menuButtons.SetActive(true);
        levelListButton.SetActive(false);
        isInLevels = false;
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        //Collectable Menu UI
        PlayerPrefs.SetInt("CooCooWisps", 0);
        PlayerPrefs.SetInt("CooCooWispsCounted", 0);
        PlayerPrefs.SetInt("CooCooPortraits", 0);
        PlayerPrefs.SetInt("CooCooPortraitsCounted", 0);

        PlayerPrefs.SetInt("PenguinWisps", 0);
        PlayerPrefs.SetInt("PenguinWispsCounted", 0);
        PlayerPrefs.SetInt("PenguinPortraits", 0);
        PlayerPrefs.SetInt("PenguinPortraitsCounted", 0);

        PlayerPrefs.SetInt("KrakatoaWisps", 0);
        PlayerPrefs.SetInt("KrakatoaWispsCounted", 0);
        PlayerPrefs.SetInt("KrakatoaPortraits", 0);
        PlayerPrefs.SetInt("KrakatoaPortraitsCounted", 0);

        PlayerPrefs.SetInt("OozelandWisps", 0);
        PlayerPrefs.SetInt("OozelandWispsCounted", 0);
        PlayerPrefs.SetInt("OozelandPortraits", 0);
        PlayerPrefs.SetInt("OozelandPortraitsCounted", 0);

        PlayerPrefs.SetInt("BackyardWisps", 0);
        PlayerPrefs.SetInt("BackyardWispsCounted", 0);
        PlayerPrefs.SetInt("BackyardPortraits", 0);
        PlayerPrefs.SetInt("BackyardPortraitsCounted", 0);

        PlayerPrefs.SetInt("KryptekWisps", 0);
        PlayerPrefs.SetInt("KryptekWispsCounted", 0);
        PlayerPrefs.SetInt("KryptekPortraits", 0);
        PlayerPrefs.SetInt("KryptekPortraitsCounted", 0);

        PlayerPrefs.SetInt("CastleWisps", 0);
        PlayerPrefs.SetInt("CastleWispsCounted", 0);
        PlayerPrefs.SetInt("CastlePortraits", 0);
        PlayerPrefs.SetInt("CastlePortraitsCounted", 0);

        PlayerPrefs.SetInt("CurrentPortraitPiece", 0);
        PlayerPrefs.SetInt("CurrentWisps", 0);

        //Game Comepletion
        PlayerPrefs.SetInt("CooCooFinished", 0);
        PlayerPrefs.SetInt("PenguinFinished", 0);
        PlayerPrefs.SetInt("KrakatoaFinished", 0);
        PlayerPrefs.SetInt("OozelandFinished", 0);
        PlayerPrefs.SetInt("BackyardFinished", 0);
        PlayerPrefs.SetInt("KryptekFinished", 0);
        PlayerPrefs.SetInt("CastleFinished", 0);
        PlayerPrefs.SetInt("GameCompleted", 0);

        //Portrait Door Saves
        PlayerPrefs.SetInt("Penguin Parkway", 0);
        PlayerPrefs.SetInt("Krakatoa", 0);
        PlayerPrefs.SetInt("Backyard Maze", 0);
        PlayerPrefs.SetInt("CooCoo Cove", 0);
        PlayerPrefs.SetInt("Kryptek Tower", 0);
        PlayerPrefs.SetInt("Vladula's Chamber", 0);

        //Portait Saves
        PlayerPrefs.SetInt("Penguin ParkwayPortrait", 0);
        PlayerPrefs.SetInt("KrakatoaPortrait", 0);
        PlayerPrefs.SetInt("Backyard MazePortrait", 0);
        PlayerPrefs.SetInt("CooCoo CovePortrait", 0);
        PlayerPrefs.SetInt("Kryptek TowerPortrait", 0);
        PlayerPrefs.SetInt("Vladula's ChamberPortrait", 0);

        //Player Abilities
        PlayerPrefs.SetInt("SpinAttackAbility", 0);
        PlayerPrefs.SetInt("ShieldAbility", 0);
        PlayerPrefs.SetInt("FireBallAbility", 0);
        PlayerPrefs.SetInt("DashAbility", 0);
        PlayerPrefs.SetInt("DecoyAbility", 0);

        //Tutorial Saves
        PlayerPrefs.SetInt("LearnTimedPlatform", 0);
        PlayerPrefs.SetInt("HubLevelTutorial", 0);
        PlayerPrefs.SetInt("KryptekChallange", 0);
        PlayerPrefs.SetInt("ToxicTrigger", 0);
        PlayerPrefs.SetInt("BossDoorTrigger", 0);
        PlayerPrefs.SetInt("FirstWispDoorTrigger", 0);
        PlayerPrefs.SetInt("PenguinTrigger", 0);
        PlayerPrefs.SetInt("VolcanoTrigger", 0);
        PlayerPrefs.SetInt("MazeTrigger", 0);
        PlayerPrefs.SetInt("MazeTrigger", 0);
        PlayerPrefs.SetInt("KryptekTrigger", 0);

        //Player Lives Save
        PlayerPrefs.SetInt("PlayerLives", 1);
        PlayerPrefs.DeleteKey("CurrLevelName");

        PlayerPrefs.SetFloat("MasterMixer", .5f);
        PlayerPrefs.SetFloat("MusicMixer", .5f);
        PlayerPrefs.SetFloat("SFXMixer", .5f);

        mixer.SetFloat("Master", Mathf.Log(.5f) * 20);
        mixer.SetFloat("Music", Mathf.Log(.5f) * 20);
        mixer.SetFloat("SFX", Mathf.Log(.5f) * 20);

        PlayerPrefs.SetFloat("PlayerMaxHealth", 8f);

        
        SaveLoad.DeleteAllSaveFiles();


    }
}
