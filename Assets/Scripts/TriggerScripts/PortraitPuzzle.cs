using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitPuzzle : MonoBehaviour
{
    private bool canInteract;
    public GameObject[] pieces;
    public Material filledMat;
    public Material emptyMat;
    [SerializeField]
    //private List<GameObject> missingPieces = new List<GameObject>();
    private GameObject[] missingPieces;
    public int missingCount;
    public CollectibleUI collectibleUI;
    public GameObject newLevelDoor;
    private AudioSource audioCue;
    private bool isCompleted;
    public AudioClip[] audioClips;
    private int temp;
    public GameObject textMesh;
    public GameObject playerCam;


    public string portaitNameReference;

    private void Awake()
    {
        collectibleUI = FindObjectOfType<CollectibleUI>();
        portaitNameReference = newLevelDoor.GetComponentInChildren<NewLevelTrigger>().levelName;
    }

    void Start()
    {
        textMesh.SetActive(false);

        if (PlayerPrefs.GetInt(portaitNameReference) < 1)
        {
            temp = PlayerPrefs.GetInt(portaitNameReference + "Portrait");

            for (int i = 0; i < missingPieces.Length - temp; i++)
            {
                bool canSet = true;
                int r = (int)Random.Range(0, pieces.Length);
                for (int a = 0; a < missingPieces.Length; a++)
                {
                    if (pieces[r] == missingPieces[a])
                    {
                        canSet = false;
                    }
                }

                if (canSet)
                {
                    pieces[r].GetComponent<MeshRenderer>().material = emptyMat;
                    missingPieces[i] = pieces[r];
                }
                else
                {
                    i--;
                }
            }
        }

        else
        {
            isCompleted = true;
            newLevelDoor.GetComponent<Animator>().SetBool("Open_Door", true);
        }

        missingCount = missingPieces.Length - temp;
        audioCue = gameObject.GetComponent<AudioSource>();




    }

    void Update()
    {
        if(canInteract && !isCompleted)
        {
            if(Input.GetButtonDown("Interact"))
            {

                if(CollectibleUI.portraits >= 1)
                {
                    audioCue.clip = audioClips[0];
                    audioCue.Play();
                    missingPieces[missingCount - 1].GetComponent<MeshRenderer>().material = filledMat;
                    missingCount--;
                    collectibleUI.UpdateCollectibles("removePortrait");

                    temp++;

                    PlayerPrefs.SetInt(portaitNameReference + "Portrait", temp);
                }
            }
        }

        if(missingCount <= 0 && canInteract)
        {
            if(!isCompleted)
            { 
                audioCue.clip = audioClips[1];
                audioCue.Play();
                newLevelDoor.GetComponent<Animator>().SetBool("Open_Door", true);
                isCompleted = true;
                canInteract = false;
            }
        }

        if (isCompleted)
        {
            missingPieces = null;
            PlayerPrefs.SetInt(portaitNameReference, 1);
        }

        textMesh.transform.LookAt(playerCam.transform.position);


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
        if (!isCompleted)
        {
            textMesh.SetActive(true);
        }
            
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }

        textMesh.SetActive(false);
    }
}
