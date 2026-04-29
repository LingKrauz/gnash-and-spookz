using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonGlassWall : MonoBehaviour
{


    public GameObject dailogueBox;
    public DialogScript dScript;
    public Animator BAnim;
    public GameObject Camera;
    public bool animIsPlaying;

    void Start()
    {

    }

    void Update()
    {
        GameManager.CollectablesUI(false);

        if (animIsPlaying)
        {
            PlayerMovement.canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.SetActive(true);
            BAnim.SetBool("PlayAnim",true);
            dailogueBox.SetActive(true);
            dScript.DisplayDialog("[Spookz] Jump over that break in the bridge with 'Space' and A on your gaming remote! I bet you can whack those enemies with 'right mouse click' or X Button your gaming Remote! Also, Remember to press C to summon your bubble shield to push enemies away!");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            animIsPlaying = true;
            PlayerPrefs.SetInt("SpinAttackAbility", 1);
            PlayerPrefs.SetInt("ShieldAbility", 1);
        }
    }

}
