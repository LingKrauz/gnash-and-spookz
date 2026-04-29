using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionCCC : MonoBehaviour
{
    public CollectibleUI PCounter;
    public int Count;
    public GameObject[] PortraitPieces;
    public GameObject YouWin;
    CollectableMenuUI ColMen;
   

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ColMen = FindObjectOfType<CollectableMenuUI>();
        PortraitPieces = GameObject.FindGameObjectsWithTag("PortraitPiece");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ColMen.coocooCurrentPortraitCount >= PortraitPieces.Length)
        {
            anim.SetBool("Open_Door", true);
            
        }
        
    }
   

}
