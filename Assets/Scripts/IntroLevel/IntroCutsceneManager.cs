using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCutsceneManager : MonoBehaviour
{
    private TextWriter.TextWriterSingle textWriterSingle;
    public GameObject cam;
    public GameObject player;
    public GameObject explosion;
    public GameObject dialogBoxUI;
    public GameObject playerControllerIntro;
    public Text textObject;
    public Transform explosionPoint;
    public Transform explosionPoint2;
    public Animator telescopeAnim;
    private Animator cutsceneAnim;
    private int dialogIndex = 0;
    private bool animFinished;
    public float typingSpeed;
    private bool isCutscenePlaying;
    public Animator pAnim;
    public Animator bAnim;
    public GameObject continueText;


    public string[] dialogsToDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
        isCutscenePlaying = true;

        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            PlayerMovement.isIntroAnim = true;
        }

        player.GetComponent<CharacterController>().enabled = false;
        cam.SetActive(false);
        PlayerMovement.canMove = false;
        cutsceneAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cam.activeSelf && !animFinished)
        {
            cam.SetActive(true);
        }
        
        if (isCutscenePlaying)
        {
            PlayerMovement.canMove = false;
            if (PlayerMovement.isIntroAnim)
            {
                pAnim.SetFloat("Velocity", .7f);
                  
            }
        }
    }

    public void TriggerExplosion()
    {
        GameObject explosion1 = Instantiate(explosion, explosionPoint.position, explosionPoint.rotation);
        telescopeAnim.SetBool("isFalling", true);
    }

    public void TriggerExplosion2()
    {
        GameObject explosion2 = Instantiate(explosion, explosionPoint2.position, explosionPoint2.rotation);
    }

    public void EndCutscene()
    {
        player.GetComponent<CharacterController>().enabled = true;
        cam.SetActive(false);
        PlayerMovement.canMove = true;
        isCutscenePlaying = false;
        cutsceneAnim.enabled = false;
        Destroy(this);
    }

    public void PlayDialog()
    {
        dialogBoxUI.SetActive(true);
        continueText.SetActive(false);
        PlayerMovement.canMove = false;
        textWriterSingle = TextWriter.AddWriter_Static(textObject, dialogsToDisplay[dialogIndex], typingSpeed, true, true);
        
    }

    public void CloseDialog()
    {
        continueText.SetActive(true);
        dialogBoxUI.SetActive(false);
        dialogIndex++;
    }
    public void TurnonPlayerMovementIntro()
    {
        playerControllerIntro.SetActive(true);
    }

    public void ResetPlayerAnim()
    {
        PlayerMovement.isIntroAnim = false;
    }

    public void BossFireProjectile()
    {
        bAnim.SetTrigger("doShoot");
    }

}
