using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpooksRope : MonoBehaviour
{
    public CharacterController cController;
    Vector3 movementDirection;
    public bool Roped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Roped == true && Input.GetKey(KeyCode.Z))
        {
            movementDirection.y = 5f;
            cController.Move(movementDirection * Time.deltaTime);
        }
        else
        {
            movementDirection.y = -2f;
            cController.Move(movementDirection * Time.deltaTime);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Roped= true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Roped = false;
        }
    }
}
