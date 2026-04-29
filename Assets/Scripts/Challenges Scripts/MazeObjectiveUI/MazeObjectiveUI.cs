using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeObjectiveUI : MonoBehaviour
{
    public Text portraitCount;
    public Text objectiveText;
    public int requiredPortraits;
    private int currPortraits;
    private bool areCollected;
    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!areCollected)
        {
            currPortraits = CollectibleUI.portraits;
            portraitCount.text = currPortraits.ToString() + " / " + requiredPortraits.ToString();
        }
        else
        {
            portraitCount.text = null;
            objectiveText.text = "Return To Castle";
        }

        if(currPortraits >= requiredPortraits )
        {
            areCollected = true;
        }

        
    }

    public void RequirementCheck()
    {
        if (areCollected)
        {
            winUI.SetActive(true);
        }
    }
}
