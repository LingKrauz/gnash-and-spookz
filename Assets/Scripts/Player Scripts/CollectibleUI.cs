using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleUI : MonoBehaviour
{
    public static int portraits;
    public static int wisps;
    public Text portraitCount;
    public Text wispsCount;
    public Animator hudAnim;
    private float timer;
    private float timerSet = 1;
    private bool fadeUI;

    private GameObject maxHealthTxt;

    public void Awake()
    {
        
    }

    void Start()
    {
        timer = timerSet;

        maxHealthTxt = GameObject.Find("MaxHealthText");
        maxHealthTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        portraits = PlayerPrefs.GetInt("CurrentPortraitPiece");
        wisps = PlayerPrefs.GetInt("CurrentWisps");

        portraitCount.text = portraits.ToString();
        wispsCount.text = wisps.ToString();

        /*if(fadeUI)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                //ResetVisibleBool();
                timer = timerSet;
            }
        }*/
    }


    public void UpdateCollectibles(string pickupName)
    {
        //hudAnim.SetBool("makeVisible", true);

        if (pickupName == "removePortrait")
        {
            portraits--;
            PlayerPrefs.SetInt("CurrentPortraitPiece", portraits);
            portraitCount.text = portraits.ToString();
        }
        
    }

    public void UpdateCollectibles(string pickupName, int QTY)
    {
        //hudAnim.SetBool("makeVisible", true);
        if (pickupName == "removeWisps")
        {
            wisps -= QTY;
            wispsCount.text = wisps.ToString();
        }
    }



    public void ResetVisibleBool()
    {
        //hudAnim.SetBool("makeVisible", false);
    }    

    public void SetMaxHealthTxtActive()
    {
        maxHealthTxt.SetActive(true);
    }
}
