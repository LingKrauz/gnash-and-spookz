using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public Transform[] spawnPoints;
    private Transform currSpawnPoint;
    private string currLevelName;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrLevelName"))
        {
            currLevelName = PlayerPrefs.GetString("CurrLevelName") + "Spawn";
            foreach (Transform name in spawnPoints)
            {
                if (name.name == currLevelName)
                {
                    currSpawnPoint = name;
                }
            }

            if (currSpawnPoint != null)
            {
                PlayerMovement.canMove = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = currSpawnPoint.position;
                player.GetComponent<CharacterController>().enabled = true;
                PlayerMovement.canMove = true;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


}


