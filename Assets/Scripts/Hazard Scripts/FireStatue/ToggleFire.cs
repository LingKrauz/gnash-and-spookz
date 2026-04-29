using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFire : MonoBehaviour
{
    private Animator anim;
    private float timer;
    public float timerSet;
    private bool isOpen;
    public GameObject flame;
    public FireBreath fBreath;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = timerSet;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
            timer = timerSet;
        }

    }

    public void EnableFlame()
    {
        flame.SetActive(true);
        fBreath.isDamaging = true;
    }

    public void DisableFlame()
    {
        flame.SetActive(false);
        fBreath.isDamaging = false;
    }




}
