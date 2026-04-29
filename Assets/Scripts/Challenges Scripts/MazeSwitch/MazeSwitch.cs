using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSwitch : MonoBehaviour
{
    public GameObject door;
    private Animator anim;
    private bool isInTrigger;
    private bool hasSwitched;
    public GameObject cutsceneCam;
    private bool canSeeDoor;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        cutsceneCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger && !hasSwitched)
        {
            if (Input.GetButtonDown("Interact"))
            {
                hasSwitched = true;
                PlayerMovement.canMove = false;
                anim.SetBool("isOn", true);
                GetComponent<AudioSource>().Play();
                StartCutscene();

                
            }
        }


        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

    public void StartCutscene()
    {
        cutsceneCam.SetActive(true);
    }

    public void EndCutscene()
    {
        cutsceneCam.SetActive(false);
        PlayerMovement.canMove = true;
    }

    public void OpenDoor()
    {
        door.GetComponent<Animator>().SetBool("isOpen", true);
    }

}
