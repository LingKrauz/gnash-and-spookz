using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//Created by: Yaimee N. Martinez Molina 11:38am MDT
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Reference Scripts")]
    CollectibleUI collectibleUI;

    [Header("Menu Defaults")]
    public GameObject PauseMenuUI;

    [Header("UI Menus")]
    public GameObject[] menus;

    [Header("Collectables UI")]
    public GameObject CollectablesMenuUI;

    
    public GameObject resumeButton;
    public GameObject backButton;
    public GameObject optionsMenu;
    public GameObject goBackButton;
    public GameObject hubQuitButton;

    private bool isInOptions;
    private bool isInCollectables;

    public GameObject[] sliders;

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 10)
        {
            hubQuitButton.GetComponent<Button>().interactable = false;
            hubQuitButton.SetActive(false);
        }
        ResumeGame();
        
        //PlayerPrefs.SetInt("Wisps", )
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                
                ResumeGame();
            }
            else
            {
                
                PauseGame();
            }
        }
        if (Input.GetButtonDown("Cancel") && isInOptions)
        {
            isInOptions = false;
            MenuReset();
        }
        else if (Input.GetButtonDown("Cancel") && isInCollectables)
        {
            isInCollectables = false;
            MenuReset();
        }

        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null && isInOptions)
        {
            EventSystem.current.SetSelectedGameObject(goBackButton);
        }
        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null && isInCollectables)
        {
            EventSystem.current.SetSelectedGameObject(backButton);
        }
        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null && !isInOptions && !isInCollectables)
        {
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }
    
    public void ResumeGame()
    {
        PlayerMovement.canMove = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PauseMenuUI.SetActive(false);
        GameIsPaused = false;

        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

    void PauseGame()
    {
        PlayerMovement.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void OpenOptions()
    {
        PauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].GetComponent<VolumeController>().ResetSlider();
        }
        isInOptions = true;
        EventSystem.current.SetSelectedGameObject(goBackButton);
    }

    public void MenuReset()
    {
        PauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
        isInOptions = false;
        isInCollectables = false;

        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

    public void QuitLevel()
    {
        PlayerPrefs.SetString("CurrLevelName", SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(0);
    }

    public void CollectablesUIIndex()
    {
        isInCollectables = true;
        PauseMenuUI.SetActive(false);
        CollectablesMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton);

    }

    public void QuitToHub()
    {
        PlayerPrefs.SetString("CurrLevelName", SceneManager.GetActiveScene().name);
        PlayerMovement.canMove = true;
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(7);
    }
}
