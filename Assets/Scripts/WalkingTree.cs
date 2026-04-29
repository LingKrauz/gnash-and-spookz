using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTree : MonoBehaviour
{
    private Animator treeAnimator;
    public GameObject tree;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        treeAnimator = tree.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            treeAnimator.SetBool("IsFlinging", true);
            Debug.Log("Landed on tree");
            player.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            treeAnimator.SetBool("IsFlinging", false);
            player.transform.parent = null;
        }
    }
}
