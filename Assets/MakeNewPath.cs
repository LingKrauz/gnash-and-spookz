using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNewPath : MonoBehaviour
{
    public GameObject BarrelBomb;
    public GameObject NewPath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!BarrelBomb.activeInHierarchy)
        {
            NewPath.SetActive(false);
        } 
    }
}
