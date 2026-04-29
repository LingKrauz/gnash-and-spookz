using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KryptWispsCheck : MonoBehaviour
{
    public GameObject Gate2Spawner;
    public GameObject Gate3Spawner;

    CollectableMenuUI wispsCounter;
    CollectableMenuUI portraitCounter;

    public Collider[] doorTriggers;
    public int numberofWisps;
    public int numberofPortraits;

    void Start()
    {
        wispsCounter = FindObjectOfType<CollectableMenuUI>();
        portraitCounter = FindObjectOfType<CollectableMenuUI>();

        Gate2Spawner.SetActive(false);
        Gate3Spawner.SetActive(false);
    }

    void Update()
    {
        WispsCheck();
        PortraitCheck();
    }

    public void WispsCheck()
    {
        if (wispsCounter.kryptekCurrentWispCount >= 40)
        {
            doorTriggers[0].enabled = true;
        }

        if (wispsCounter.kryptekCurrentWispCount >= 80)
        {
            doorTriggers[1].enabled = true;
        }
    }

    public void PortraitCheck()
    {
        if(portraitCounter.kryptekCurrentPortraitCount >= 2)
        {
            Gate2Spawner.SetActive(true);
        }

        if (portraitCounter.kryptekCurrentPortraitCount >= 3)
        {
            Gate3Spawner.SetActive(true);
        }

        if (portraitCounter.kryptekCurrentPortraitCount >= 5)
        {
            doorTriggers[2].enabled = true;
        }
    }
}
