using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    private TextWriter.TextWriterSingle textWriterSingle;
    public string dialogToPrint;
    public Text textObject;
    public GameObject dialogBoxUI;
    public float typingSpeed = .025f;
    private bool isTyping;
    private bool messageCompleted;
    public Animator sAnim;

    void Start()
    {
        dialogBoxUI.SetActive(false);
    }

    void Update()
    {
        if (isTyping)
        {

            if (messageCompleted)
            {
                if (Input.GetButtonDown("Submit"))
                {
                    dialogBoxUI.SetActive(false);
                    isTyping = false;
                    messageCompleted = false;
                    PlayerMovement.canMove = true;
                    sAnim.SetBool("doShrink", true);
                    PlayerHealth.isInCutscene = false;
                    GameManager.AbilitesUI(true);
                    GameManager.CollectablesUI(true);
                    GameManager.HealthUI(true);
                }
            }

            if (Input.GetButtonDown("Submit") && textWriterSingle != null && textWriterSingle.IsActive())
            {
                textWriterSingle.WriteAllAndDestroy();
                messageCompleted = true;
            }
            else if (!textWriterSingle.IsActive())
            {
                messageCompleted = true;
            }

        }

    }

    public void DisplayDialog()
    {
        dialogBoxUI.SetActive(true);
        PlayerHealth.isInCutscene = true;
        PlayerMovement.canMove = false;
        sAnim.SetBool("doShrink", false);
        GameManager.AbilitesUI(false);
        GameManager.CollectablesUI(false);
        GameManager.HealthUI(false);
        textWriterSingle = TextWriter.AddWriter_Static(textObject, dialogToPrint, typingSpeed, true, true);
        isTyping = true;
    }

    public void DisplayDialog(string textToPrint)
    {
        dialogBoxUI.SetActive(true);
        PlayerHealth.isInCutscene = true;
        PlayerMovement.canMove = false;
        sAnim.SetBool("doShrink", false);
        GameManager.AbilitesUI(false);
        GameManager.CollectablesUI(false);
        GameManager.HealthUI(false);
        textWriterSingle = TextWriter.AddWriter_Static(textObject, textToPrint, typingSpeed, true, true);
        isTyping = true;
    }
}
