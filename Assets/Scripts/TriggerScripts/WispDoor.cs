using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WispDoor : MonoBehaviour
{
    public CollectibleUI collectibleUI;
    public Animator anim;
    public bool isDoorOpen;
    public int requiredQTY;
    public GameObject textHolder;
    public TextMeshPro textQTY;
    public bool isCustomCheck;
    public CollectableMenuUI colMenUI;
    public GameObject wispDoor;
    public Collider trigger;

    private DoorSet doorSet;
    private UniqueID uniqueID;


    void Start()
    {
        collectibleUI = GameObject.Find("HUD").GetComponent<CollectibleUI>();
        uniqueID = GetComponent<UniqueID>();
        doorSet = FindObjectOfType<DoorSet>();
        anim = gameObject.GetComponent<Animator>();
        textQTY.text = requiredQTY.ToString();

        if (doorSet.WispDoors.Contains(uniqueID.ID))
        {
            wispDoor.SetActive(false);
            trigger.enabled = false;
            return;
        }
    }

    void Update()
    {
       if(isDoorOpen && !anim.GetBool("isOpening"))
        {
            anim.SetBool("isOpening", isDoorOpen);
            textHolder.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isCustomCheck)
        {
            if(other.tag == "Player" && ( CollectibleUI.wisps >= requiredQTY))
            {
                //other.GetComponentInChildren<CollectibleUI>().UpdateCollectibles("removeWisps", requiredQTY);
                isDoorOpen = true;
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Backyard_Maze")
            {
                if (colMenUI.backyardCurrentWispCount >= requiredQTY)
                {
                    isDoorOpen = true;
                }
            }
        }

        if (other.GetComponent<PlayerMovement>())
        {
            doorSet.WispDoors.Add(uniqueID.ID);
            doorSet.Save();
        }
    }
}
