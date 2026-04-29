using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDialogueOFF : MonoBehaviour
{
   public GameObject GlassWall;
    public GameObject DBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlassWall.activeInHierarchy)
        {
            DBox.SetActive(false);
        }
    }
}
