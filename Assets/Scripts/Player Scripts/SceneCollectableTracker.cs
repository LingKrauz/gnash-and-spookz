using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCollectableTracker : MonoBehaviour
{
    public Text sceneName;
    public Text portraitTracker;
    public Text wispTracker;

    void Start()
    {
        sceneName.text = SceneManager.GetActiveScene().name;
    }

    
    void Update()
    {
        Tracker();
        GameCompletion();
    }

    public void GameCompletion()
    {
        if(PlayerPrefs.GetInt("CooCooFinished") == 1)
        {
            if(PlayerPrefs.GetInt("PenguinFinished") == 1)
            {
                if(PlayerPrefs.GetInt("KrakatoaFinished") == 1)
                {
                    if(PlayerPrefs.GetInt("OozelandFinished") == 1)
                    {
                        if(PlayerPrefs.GetInt("BackyardFinished") == 1)
                        {
                            if(PlayerPrefs.GetInt("KryptekFinished") == 1)
                            {
                                if(PlayerPrefs.GetInt("CastleFinished") == 1)
                                {
                                    PlayerPrefs.SetInt("GameCompleted", 1);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void Tracker()
    {
        if (SceneManager.GetActiveScene().name == "CoocooCorsairCove")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Coocoo Corsair Cove";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("CooCooPortraits").ToString() + " / " + PlayerPrefs.GetInt("CooCooPortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("CooCooWisps").ToString() + " / " + PlayerPrefs.GetInt("CooCooWispsCounted").ToString();

            if (PlayerPrefs.GetInt("CooCooPortraits") >= PlayerPrefs.GetInt("CooCooPortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("CooCooWisps") >= PlayerPrefs.GetInt("CooCooWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }

            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("CooCooFinished", 1);
            }
        }

        else if (SceneManager.GetActiveScene().name == "PenguinParkway")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Penguin Parkway";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("PenguinPortraits").ToString() + " / " + PlayerPrefs.GetInt("PenguinPortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("PenguinWisps").ToString() + " / " + PlayerPrefs.GetInt("PenguinWispsCounted").ToString();

            if (PlayerPrefs.GetInt("PenguinPortraits") >= PlayerPrefs.GetInt("PenguinPortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("PenguinWisps") >= PlayerPrefs.GetInt("PenguinWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }

            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("PenguinFinished", 1);
            }
        }

        else if (SceneManager.GetActiveScene().name == "KrakatoaVolcano")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Krakatoa Volcano";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("KrakatoaPortraits").ToString() + " / " + PlayerPrefs.GetInt("KrakatoaPortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("KrakatoaWisps").ToString() + " / " + PlayerPrefs.GetInt("KrakatoaWispsCounted").ToString();

            if (PlayerPrefs.GetInt("KrakatoaPortraits") >= PlayerPrefs.GetInt("KrakatoaPortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("KrakatoaWisps") >= PlayerPrefs.GetInt("KrakatoaWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }

            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("KrakatoaFinished", 1);
            }
        }

        else if (SceneManager.GetActiveScene().name == "GreenOozeland")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Green Oozeland";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("OozelandPortraits").ToString() + " / " + PlayerPrefs.GetInt("OozelandPortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("OozelandWisps").ToString() + " / " + PlayerPrefs.GetInt("OozelandWispsCounted").ToString();

            if (PlayerPrefs.GetInt("OozelandPortraits") >= PlayerPrefs.GetInt("OozelandPortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("OozelandWisps") >= PlayerPrefs.GetInt("OozelandWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }

            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("OozelandFinished", 1);
            }
        }

        else if (SceneManager.GetActiveScene().name == "Backyard_Maze")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Backyard Maze";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("BackyardPortraits").ToString() + " / " + PlayerPrefs.GetInt("BackyardPortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("BackyardWisps").ToString() + " / " + PlayerPrefs.GetInt("BackyardWispsCounted").ToString();

            if (PlayerPrefs.GetInt("BackyardPortraits") >= PlayerPrefs.GetInt("BackyardPortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("BackyardWisps") >= PlayerPrefs.GetInt("BackyardWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }

            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("BackyardFinished", 1);
            }
        }

        else if (SceneManager.GetActiveScene().name == "KryptekTower")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Kryptek Tower";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("KryptekPortraits").ToString() + " / " + PlayerPrefs.GetInt("KryptekPortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("KryptekWisps").ToString() + " / " + PlayerPrefs.GetInt("KryptekWispsCounted").ToString();

            if (PlayerPrefs.GetInt("KryptekPortraits") >= PlayerPrefs.GetInt("KryptekPortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("KryptekWisps") >= PlayerPrefs.GetInt("KryptekWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }


            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("KryptekFinished", 1);
            }
        }

        else if (SceneManager.GetActiveScene().name == "HubLevel")
        {
            bool portaitDone = false;
            bool wispDone = false;

            sceneName.text = "Castle";
            portraitTracker.text = "Portraits: " + PlayerPrefs.GetInt("CastlePortraits").ToString() + " / " + PlayerPrefs.GetInt("CastlePortraitsCounted").ToString();
            wispTracker.text = "Wisps: " + PlayerPrefs.GetInt("CastleWisps").ToString() + " / " + PlayerPrefs.GetInt("CastleWispsCounted").ToString();

            if (PlayerPrefs.GetInt("CastlePortraits") >= PlayerPrefs.GetInt("CastlePortraitsCounted"))
            {
                portraitTracker.color = Color.green;
                portaitDone = true;
            }

            else
            {
                portraitTracker.color = Color.black;
                portaitDone = false;
            }

            if (PlayerPrefs.GetInt("CastleWisps") >= PlayerPrefs.GetInt("CastleWispsCounted"))
            {
                wispTracker.color = Color.green;
                wispDone = true;
            }

            else
            {
                wispTracker.color = Color.black;
                wispDone = false;
            }

            if (portaitDone && wispDone)
            {
                PlayerPrefs.SetInt("CastleFinished", 1);
            }
        }

        if(sceneName.text == null)
        {
            sceneName.text = SceneManager.GetActiveScene().name;
        }
    }
}
