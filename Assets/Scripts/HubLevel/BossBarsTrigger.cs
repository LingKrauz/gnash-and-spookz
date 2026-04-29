using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarsTrigger : MonoBehaviour
{
    public Animator anim;
    public int requiredQTY;

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
        if (other.tag == "Player" && (CollectibleUI.wisps >= requiredQTY))
        {
            //other.GetComponentInChildren<CollectibleUI>().UpdateCollectibles("removeWisps", requiredQTY);
            anim.SetBool("isOpen", true);
        }
    }
}
