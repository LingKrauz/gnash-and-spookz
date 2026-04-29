using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public CollectableMenuUI collectableText;

    public int collectedWisps;
    public int collectedPortraits;

    public GameObject[] wispsObjects;

    private CollectableItemSet collectableItemSet;
    private DoorSet doorSet;

    private GameObject abilitiesHolder;
    private GameObject colletableHUDHolder;
    private GameObject colletableTrackerHolder;
    private GameObject healthHUD;

    private static GameObject abilities;
    private static GameObject colletableHUD;
    private static GameObject colletableTracker;
    private static GameObject playerHealth;

    void Awake()
    {
        collectableText = FindObjectOfType<CollectableMenuUI>();

        collectableItemSet = FindObjectOfType<CollectableItemSet>();
        collectableItemSet.Load();

        doorSet = FindObjectOfType<DoorSet>();
        doorSet.Load();

        wispsObjects = GameObject.FindGameObjectsWithTag("Wisp");

        abilitiesHolder = GameObject.Find("AbilityCooldowns");
        colletableHUDHolder = GameObject.Find("CollectablesUIs");
        colletableTrackerHolder = GameObject.Find("LevelCollectables");
        healthHUD = GameObject.Find("HealthBar");

        abilities = abilitiesHolder;
        colletableHUD = colletableHUDHolder;
        colletableTracker = colletableTrackerHolder;
        playerHealth = healthHUD;

        if(SceneManager.GetActiveScene().name == "IntroLevel")
        {
            HUD(false);
        }

        if(SceneManager.GetActiveScene().name == "Titanic Towering Throne")
        {
            CollectablesUI(false);
        }
    }

    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayerPrefs.SetInt("CurrentPortraitPiece", 100);
                PlayerPrefs.SetInt("CurrentWisps", 300);

                PlayerPrefs.SetInt("SpinAttackAbility", 1);
                PlayerPrefs.SetInt("ShieldAbility", 1);
                PlayerPrefs.SetInt("FireBallAbility", 1);
                PlayerPrefs.SetInt("DashAbility", 1);
                PlayerPrefs.SetInt("DecoyAbility", 1);
                print("Admin Mode Enabled");
            }
        }
        */
    }

    public void CollectedWisp()
    {
        if(SceneManager.GetActiveScene().name == "CoocooCorsairCove")
        {
            collectableText.coocooCurrentWispCount++;
        }

        else if(SceneManager.GetActiveScene().name == "PenguinParkway")
        {
            collectableText.penguinCurrentWispCount++;
        }

        else if (SceneManager.GetActiveScene().name == "KrakatoaVolcano")
        {
            collectableText.krakatoaCurrentWispCount++;
        }

        else if (SceneManager.GetActiveScene().name == "GreenOozeland")
        {
            collectableText.oozelandCurrentWispCount++;
        }

        else if (SceneManager.GetActiveScene().name == "Backyard_Maze")
        {
            collectableText.backyardCurrentWispCount++;
        }

        else if (SceneManager.GetActiveScene().name == "KryptekTower")
        {
            collectableText.kryptekCurrentWispCount++;
        }

        else if (SceneManager.GetActiveScene().name == "HubLevel")
        {
            collectableText.castleCurrentWispCount++;
        }
    }

    public void CollectedPortraitPiece()
    {
        if (SceneManager.GetActiveScene().name == "CoocooCorsairCove")
        {
            collectableText.coocooCurrentPortraitCount++;
        }

        else if (SceneManager.GetActiveScene().name == "PenguinParkway")
        {
            collectableText.penguinCurrentPortraitCount++;
        }

        else if (SceneManager.GetActiveScene().name == "KrakatoaVolcano")
        {
            collectableText.krakatoaCurrentPortraitCount++;
        }

        else if (SceneManager.GetActiveScene().name == "GreenOozeland")
        {
            collectableText.oozelandCurrentPortraitCount++;
        }

        else if (SceneManager.GetActiveScene().name == "Backyard_Maze")
        {
            collectableText.backyardCurrentPortraitCount++;
        }

        else if (SceneManager.GetActiveScene().name == "KryptekTower")
        {
            collectableText.kryptekCurrentPortraitCount++;
        }

        else if (SceneManager.GetActiveScene().name == "HubLevel")
        {
            collectableText.castleCurrentPortraitCount++;
        }
    }

    public static void HUD(bool _bool)
    {
        if (_bool)
        {
            abilities.SetActive(true);
            colletableHUD.SetActive(true);
            colletableTracker.SetActive(true);
            playerHealth.SetActive(true);
        }

        else if (!_bool)
        {
            abilities.SetActive(false);
            colletableHUD.SetActive(false);
            colletableTracker.SetActive(false);
            playerHealth.SetActive(false);
        }
    }

    public static void AbilitesUI(bool _bool)
    {
        if (_bool)
        {
            abilities.SetActive(true);
        }

        else if (!_bool)
        {
            abilities.SetActive(false);
        }
    }

    public static void CollectablesUI(bool _bool)
    {
        if (_bool)
        {
            colletableTracker.SetActive(true);
        }

        else if (!_bool)
        {
            colletableTracker.SetActive(false);
        }
    }

    public static void HealthUI(bool _bool)
    {
        if (_bool)
        {
            playerHealth.SetActive(true);
        }

        else if (!_bool)
        {
            playerHealth.SetActive(false);
        }
    }
}