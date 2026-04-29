using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public GameObject hammer;
    public GameObject hammerCollider;
    public AudioController soundPlayer;
    public PlayerHealth pHealth;
    public Animator pAnim;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HammerAudio()
    {
        soundPlayer.PlaySpinAttack();
        
    }
    public void DisableHammer()
    {
        hammer.SetActive(false);
        pAnim.SetBool("doSwing", false);
    }

    public void RespawnPlayerCheck()
    {
        pHealth.RespawnCheck();
    }

    public void EnableDamage()
    {
        hammerCollider.SetActive(true);
    }

    public void DisableDamage()
    {
        hammerCollider.SetActive(false);
    }
}
