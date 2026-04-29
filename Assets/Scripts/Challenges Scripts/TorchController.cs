using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Mitchell Kraus 12/14/2021

public class TorchController : MonoBehaviour
{
    public GameObject[] torchArray = new GameObject[4];
    public GameObject puzzlePiece;
    bool notDestroyed = true;
    //private bool[] trueArray = new bool[4];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(torchArray[0].activeSelf && torchArray[1].activeSelf && torchArray[2].activeSelf && torchArray[3].activeSelf && notDestroyed)
        {
            //Debug.Log("This is now true");
            puzzlePiece.SetActive(true);
            notDestroyed = false;
        }
    }
}
