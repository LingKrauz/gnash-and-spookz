using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitPieceDoor : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }
}
