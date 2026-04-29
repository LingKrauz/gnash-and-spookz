using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossCutsceneManager : MonoBehaviour
{
    private TextWriter.TextWriterSingle textWriterSingle;
    public GameObject startCam;
    public GameObject gnashCam;
    public GameObject bossCam;
    public GameObject dialogBoxUI;
    public GameObject bossHealthUI;
    private Animator anim;
    public BossScript bossS;
    public BossPhaseChange phase;
    public Text textObject;
    private int dialogIndex = 0;
    public float typingSpeed = 0.02f;

    public string[] dialogsToDisplay;
    private bool isAnimPlaying;
    public Animator sAnim;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sAnim.SetBool("doShrink", false);
        GameManager.HUD(false);
        gnashCam.SetActive(false);
        bossCam.SetActive(false);
        bossHealthUI.SetActive(false);
        bossS.isPaused = true;
        isAnimPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimPlaying)
        {
            PlayerMovement.canMove = false;
        }
    }

    public void EnableBossCam()
    {
        isAnimPlaying = true;
        sAnim.SetBool("doShrink", false);
        GameManager.HUD(false);
        CloseDialog();
        gnashCam.SetActive(false);
        bossHealthUI.SetActive(false);
        bossCam.SetActive(true);
        PlayDialog();
    }

    public void EnableGnashCam()
    {
        isAnimPlaying = true;
        sAnim.SetBool("doShrink", false);
        GameManager.HUD(false);
        CloseDialog();
        bossCam.SetActive(false);
        bossHealthUI.SetActive(false);
        gnashCam.SetActive(true);
        PlayDialog();
    }

    public void PlayDialog()
    {
        dialogBoxUI.SetActive(true);
        sAnim.SetBool("doShrink", false);
        textWriterSingle = TextWriter.AddWriter_Static(textObject, dialogsToDisplay[dialogIndex], typingSpeed, true, true);
        GameManager.HUD(false);
        bossHealthUI.SetActive(false);
    }

    public void CloseDialog()
    {
        dialogBoxUI.SetActive(false);
        dialogIndex++;
        GameManager.HUD(true);
        bossHealthUI.SetActive(true);
    }

    public void EndScene()
    {
        isAnimPlaying = false;
        sAnim.SetBool("doShrink", true);

        startCam.SetActive(false);
        dialogBoxUI.SetActive(false);
        bossCam.SetActive(false);
        gnashCam.SetActive(false);
        bossS.isPaused = false;
        PlayerMovement.canMove = true;
        GameManager.HUD(true);
        bossHealthUI.SetActive(true);
    }

    public void PlayPhase2()
    {
        bossS.isPaused = true;
        PlayerMovement.canMove = false;
        anim.SetBool("doAnim2", true);
        EnableBossCam();

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject enemy in taggedObjects)
        {
            Destroy(enemy);
        }

        GameObject[] taggedObjects1 = GameObject.FindGameObjectsWithTag("Bat_Enemy");
        foreach (GameObject enemy in taggedObjects1)
        {
            Destroy(enemy);
        }

        GameObject[] taggedObjects2 = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in taggedObjects2)
        {
            if (enemy != bossS.gameObject)
            {
                Destroy(enemy);
            }
        }


    }

    public void ResetPhase2()
    {
        anim.SetBool("doAnim2", false);
    }

    public void PlayPhase3()
    {
        bossS.isPaused = true;
        PlayerMovement.canMove = false;
        anim.SetBool("doAnim3", true);
        EnableBossCam();

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject enemy in taggedObjects)
        {
            Destroy(enemy);
        }

        GameObject[] taggedObjects1 = GameObject.FindGameObjectsWithTag("Bat_Enemy");
        foreach (GameObject enemy in taggedObjects1)
        {
            Destroy(enemy);
        }

        GameObject[] taggedObjects2 = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in taggedObjects2)
        {
            if (enemy != bossS.gameObject)
            {
                Destroy(enemy);
            }
        }
    }

    public void ResetPhase3()
    {
        anim.SetBool("doAnim3", false);
    }

    public void PlayPhase4()
    {
        PlayerMovement.canMove = false;
        anim.SetBool("doAnim4", true);
        EnableBossCam();

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject enemy in taggedObjects)
        {
            Destroy(enemy);
        }

        GameObject[] taggedObjects1 = GameObject.FindGameObjectsWithTag("Bat_Enemy");
        foreach (GameObject enemy in taggedObjects1)
        {
            Destroy(enemy);
        }

        GameObject[] taggedObjects2 = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in taggedObjects2)
        {
            if (enemy != bossS.gameObject)
            {
                Destroy(enemy);
            }
        }
    }

    public void ResetPhase4()
    {
        anim.SetBool("doAnim4", false);
    }

    public void SwitchPhase2()
    {
        phase.DoPhase2();
    }

    public void SwitchPhase3()
    {
        phase.DoPhase3();
    }

    public void KillBoss()
    {
        
        CloseDialog();
        bossS.KillBoss();
        

        

    }
    
    public void FinishGame()
    {
        SceneManager.LoadScene(9);
    }
}
