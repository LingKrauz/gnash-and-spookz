using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingWall : MonoBehaviour
{
    private ClosingWalls wall;

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("ClosingWalls").GetComponent<ClosingWalls>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.SetWallBool(gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.ResetWallBool(gameObject.name);
        }
    }
}
