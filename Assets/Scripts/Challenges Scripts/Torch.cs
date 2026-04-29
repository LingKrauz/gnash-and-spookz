using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Mitchell Kraus 12/13/2021

public class Torch : MonoBehaviour
{
    public AudioSource flameSound;
    bool isLit = false;

    [SerializeField]
    GameObject Flame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //Debug.Log("Projectile hit");
            //isLit = true;
            Flame.SetActive(true);
            if (!isLit)
            {
                flameSound.Play();
            }
            isLit = true;
        }
    }
}
