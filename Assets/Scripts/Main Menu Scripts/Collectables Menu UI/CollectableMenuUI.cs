using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectableMenuUI : MonoBehaviour
{
    [Header("Levels Wisps Count Text")]
    public Text coocooWispTxt;
    public int coocooCurrentWispCount;
    private int coocooWispCount;
    public Text penguinWispTxt;
    public int penguinCurrentWispCount;
    private int penguinWispCount;
    public Text krakatoaWispTxt;
    public int krakatoaCurrentWispCount;
    private int krakatoaWispCount;
    public Text oozelandWispTxt;
    public int oozelandCurrentWispCount;
    private int oozelandWispCount;
    public Text backyardWispTxt;
    public int backyardCurrentWispCount;
    private int backyardWispCount;
    public Text kryptekWispTxt;
    public int kryptekCurrentWispCount;
    private int kryptekWispCount;
    public Text castleWispTxt;
    public int castleCurrentWispCount;
    private int castleWispCount;

    [Header("Levels Wisps Count Text")]
    public Text coocooPortraitTxt;
    public int coocooCurrentPortraitCount;
    private int coocooPortraitCount;
    public Text penguinPortraitTxt;
    public int penguinCurrentPortraitCount;
    private int penguinPortraitCount;
    public Text krakatoaPortraitTxt;
    public int krakatoaCurrentPortraitCount;
    private int krakatoaPortraitCount;
    public Text oozelandPortraitTxt;
    public int oozelandCurrentPortraitCount;
    private int oozelandPortraitCount;
    public Text backyardPortraitTxt;
    public int backyardCurrentPortraitCount;
    private int backyardPortraitCount;
    public Text kryptekPortraitTxt;
    public int kryptekCurrentPortraitCount;
    private int kryptekPortraitCount;
    public Text castlePortraitTxt;
    public int castleCurrentPortraitCount;
    private int castlePortraitCount;

    public GameManager gameManager;

    private void Awake()
    {
        coocooCurrentWispCount = PlayerPrefs.GetInt("CooCooWisps");
        penguinCurrentWispCount = PlayerPrefs.GetInt("PenguinWisps");
        krakatoaCurrentWispCount = PlayerPrefs.GetInt("KrakatoaWisps");
        oozelandCurrentWispCount = PlayerPrefs.GetInt("OozelandWisps");
        backyardCurrentWispCount = PlayerPrefs.GetInt("BackyardWisps");
        kryptekCurrentWispCount = PlayerPrefs.GetInt("KryptekWisps");
        castleCurrentWispCount = PlayerPrefs.GetInt("CastleWisps");

        coocooCurrentPortraitCount = PlayerPrefs.GetInt("CooCooPortraits");
        penguinCurrentPortraitCount = PlayerPrefs.GetInt("PenguinPortraits");
        krakatoaCurrentPortraitCount = PlayerPrefs.GetInt("KrakatoaPortraits");
        oozelandCurrentPortraitCount = PlayerPrefs.GetInt("OozelandPortraits");
        backyardCurrentPortraitCount = PlayerPrefs.GetInt("BackyardPortraits");
        kryptekCurrentPortraitCount = PlayerPrefs.GetInt("KryptekPortraits");
        castleCurrentPortraitCount = PlayerPrefs.GetInt("CastlePortraits");

        StoreCollectedCollectableInfo();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        StoreCurrentCollectableInfo();
    }

    public void StoreCurrentCollectableInfo()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (SceneManager.GetActiveScene().name == "CoocooCorsairCove")
        {
            for (int i = coocooWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                coocooWispCount++;
            }

            for (int i = coocooPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                coocooPortraitCount++;
            }

            PlayerPrefs.SetInt("CooCooWisps", coocooCurrentWispCount);
            PlayerPrefs.SetInt("CooCooPortraits", coocooCurrentPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "PenguinParkway")
        {
            for (int i = penguinWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                penguinWispCount++;
            }

            for (int i = penguinPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                penguinPortraitCount++;
            }

            PlayerPrefs.SetInt("PenguinWisps", penguinCurrentWispCount);
            PlayerPrefs.SetInt("PenguinPortraits", penguinCurrentPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "KrakatoaVolcano")
        {
            for (int i = krakatoaWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                krakatoaWispCount++;
            }

            for (int i = krakatoaPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                krakatoaPortraitCount++;
            }

            PlayerPrefs.SetInt("KrakatoaWisps", krakatoaCurrentWispCount);
            PlayerPrefs.SetInt("KrakatoaPortraits", krakatoaCurrentPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "GreenOozeland")
        {
            for (int i = oozelandWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                oozelandWispCount++;
            }

            for (int i = oozelandPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                oozelandPortraitCount++;
            }

            PlayerPrefs.SetInt("OozelandWisps", oozelandCurrentWispCount);
            PlayerPrefs.SetInt("OozelandPortraits", oozelandCurrentPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "Backyard_Maze")
        {
            for (int i = backyardWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                backyardWispCount++;
            }

            for (int i = backyardPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                backyardPortraitCount++;
            }

            PlayerPrefs.SetInt("BackyardWisps", backyardCurrentWispCount);
            PlayerPrefs.SetInt("BackyardPortraits", backyardCurrentPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "KryptekTower")
        {
            for (int i = kryptekWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                kryptekWispCount++;
            }

            for (int i = kryptekPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                kryptekPortraitCount++;
            }

            PlayerPrefs.SetInt("KryptekWisps", kryptekCurrentWispCount);
            PlayerPrefs.SetInt("KryptekPortraits", kryptekCurrentPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "HubLevel")
        {
            for (int i = castleWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                castleWispCount++;
            }

            for (int i = castlePortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                castlePortraitCount++;
            }

            PlayerPrefs.SetInt("CastleWisps", castleCurrentWispCount);
            PlayerPrefs.SetInt("CastlePortraits", castleCurrentPortraitCount);
        }

        TextCheck();
    }

    public void StoreCollectedCollectableInfo()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (SceneManager.GetActiveScene().name == "CoocooCorsairCove")
        {
            for (int i = coocooWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                coocooWispCount++;
            }

            for (int i = coocooPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                coocooPortraitCount++;
            }

            PlayerPrefs.SetInt("CooCooWispsCounted", coocooWispCount);
            PlayerPrefs.SetInt("CooCooPortraitsCounted", coocooPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "PenguinParkway")
        {
            for (int i = penguinWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                penguinWispCount++;
            }

            for (int i = penguinPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                penguinPortraitCount++;
            }

            PlayerPrefs.SetInt("PenguinWispsCounted", penguinWispCount);
            PlayerPrefs.SetInt("PenguinPortraitsCounted", penguinPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "KrakatoaVolcano")
        {
            for (int i = krakatoaWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                krakatoaWispCount++;
            }

            for (int i = krakatoaPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                krakatoaPortraitCount++;
            }

            PlayerPrefs.SetInt("KrakatoaWispsCounted", krakatoaWispCount);   
            PlayerPrefs.SetInt("KrakatoaPortraitsCounted", krakatoaPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "GreenOozeland")
        {
            for (int i = oozelandWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                oozelandWispCount++;
            }

            for (int i = oozelandPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                oozelandPortraitCount++;
            }

            PlayerPrefs.SetInt("OozelandWispsCounted", oozelandWispCount);
            PlayerPrefs.SetInt("OozelandPortraitsCounted", oozelandPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "Backyard_Maze")
        {
            for (int i = backyardWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                backyardWispCount++;
            }

            for (int i = backyardPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                backyardPortraitCount++;
            }

            PlayerPrefs.SetInt("BackyardWispsCounted", backyardWispCount);
            PlayerPrefs.SetInt("BackyardPortraitsCounted", backyardPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "KryptekTower")
        {
            for (int i = kryptekWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                kryptekWispCount++;
            }

            for (int i = kryptekPortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                kryptekPortraitCount++;
            }

            PlayerPrefs.SetInt("KryptekWispsCounted", kryptekWispCount);    
            PlayerPrefs.SetInt("KryptekPortraitsCounted", kryptekPortraitCount);
        }

        else if (SceneManager.GetActiveScene().name == "HubLevel")
        {
            for (int i = castleWispCount; i < GameObject.FindGameObjectsWithTag("Wisp").Length; i++)
            {
                castleWispCount++;
            }

            for (int i = castlePortraitCount; i < GameObject.FindGameObjectsWithTag("PortraitPiece").Length; i++)
            {
                castlePortraitCount++;
            }

            PlayerPrefs.SetInt("CastleWispsCounted", castleWispCount);
            PlayerPrefs.SetInt("CastlePortraitsCounted", castlePortraitCount);
        }

        TextCheck();
    }

    public void TextCheck()
    {
        if(PlayerPrefs.GetInt("CooCooWispsCounted") > 0)
        {
            coocooWispTxt.text = PlayerPrefs.GetInt("CooCooWisps").ToString() + " / " + PlayerPrefs.GetInt("CooCooWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("CooCooPortraitsCounted") > 0)
        {
            coocooPortraitTxt.text = PlayerPrefs.GetInt("CooCooPortraits").ToString() + " / " + PlayerPrefs.GetInt("CooCooPortraitsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("PenguinWispsCounted") > 0)
        {
            penguinWispTxt.text = PlayerPrefs.GetInt("PenguinWisps").ToString() + " / " + PlayerPrefs.GetInt("PenguinWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("PenguinPortraitsCounted") > 0)
        {
            penguinPortraitTxt.text = PlayerPrefs.GetInt("PenguinPortraits").ToString() + " / " + PlayerPrefs.GetInt("PenguinPortraitsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("KrakatoaWispsCounted") > 0)
        {
            krakatoaWispTxt.text = PlayerPrefs.GetInt("KrakatoaWisps").ToString() + " / " + PlayerPrefs.GetInt("KrakatoaWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("KrakatoaPortraitsCounted") > 0)
        {
            krakatoaPortraitTxt.text = PlayerPrefs.GetInt("KrakatoaPortraits").ToString() + " / " + PlayerPrefs.GetInt("KrakatoaPortraitsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("OozelandWispsCounted") > 0)
        {
            oozelandWispTxt.text = PlayerPrefs.GetInt("OozelandWisps").ToString() + " / " + PlayerPrefs.GetInt("OozelandWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("OozelandPortraitsCounted") > 0)
        {
            oozelandPortraitTxt.text = PlayerPrefs.GetInt("OozelandPortraits").ToString() + " / " + PlayerPrefs.GetInt("OozelandPortraitsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("BackyardWispsCounted") > 0)
        {
            backyardWispTxt.text = PlayerPrefs.GetInt("BackyardWisps").ToString() + " / " + PlayerPrefs.GetInt("BackyardWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("BackyardPortraitsCounted") > 0)
        {
            backyardPortraitTxt.text = PlayerPrefs.GetInt("BackyardPortraits").ToString() + " / " + PlayerPrefs.GetInt("BackyardPortraitsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("KryptekWispsCounted") > 0)
        {
            kryptekWispTxt.text = PlayerPrefs.GetInt("KryptekWisps").ToString() + " / " + PlayerPrefs.GetInt("KryptekWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("KryptekPortraitsCounted") > 0)
        {
            kryptekPortraitTxt.text = PlayerPrefs.GetInt("KryptekPortraits").ToString() + " / " + PlayerPrefs.GetInt("KryptekPortraitsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("CastleWispsCounted") > 0)
        {
            castleWispTxt.text = PlayerPrefs.GetInt("CastleWisps").ToString() + " / " + PlayerPrefs.GetInt("CastleWispsCounted").ToString();
        }

        if (PlayerPrefs.GetInt("CastlePortraitsCounted") >= 0)
        {
            castlePortraitTxt.text = PlayerPrefs.GetInt("CastlePortraits").ToString() + " / " + PlayerPrefs.GetInt("CastlePortraitsCounted").ToString();
        }
    }
}
