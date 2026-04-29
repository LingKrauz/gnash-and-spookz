using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_Says : MonoBehaviour
{
    public Renderer[] buttons;
    public GameObject portraitPiece;
    public AudioSource wrongSFX;
    public AudioSource rightSFX;
    public AudioSource challengeCompletedSFX;
    public AudioSource lightUpSFX;

    public Challenge_Defeat_Enemy completeText;

    Color defaultColor;
    Color highLightColor;
    Color failColor;
    Color successColor;

    public int firstIndex;
    public int secondIndex;
    public int thirdIndex;
    public int fourthIndex;

    public int counter;

    public bool hasSucceeded;
    public bool hasFailed;
    public bool playerLeft;
    public bool hasStopped;

    void Start()
    {
        portraitPiece.SetActive(false);
        counter = 0;

        defaultColor = new Color(0f, 0f, 0f);
        highLightColor = new Color(.65f, .65f, .65f);
        failColor = new Color(1.40f, 0f, 0f);
        successColor = new Color(0f, 1.40f, 0f);

    }

    public void TriggerStartCoroutine()
    {
        StartCoroutine(StartChallenge());
    }

    public void TriggerStopCoroutine()
    {
        StopAllCoroutines();
        playerLeft = true;
        buttons[firstIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = false;
        buttons[secondIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = false;
        buttons[thirdIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = false;
        buttons[fourthIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = false;

        buttons[firstIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        buttons[secondIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        buttons[thirdIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        buttons[fourthIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        counter = 0;
        hasFailed = false;
        hasStopped = true;

    }

    void Update()
    {
        SequenceCheck();
    }

    public void Reset()
    {
        counter = 0;

        hasSucceeded = false;
        hasFailed = false;
    }

    public void SequenceCheck()
    {
        if (!hasSucceeded && !hasStopped)
        {
            if (counter == 0)
            {
                buttons[firstIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = true;
            }

            if (counter == 1)
            {
                buttons[secondIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = true;
            }

            if (counter == 2)
            {
                buttons[thirdIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = true;
            }

            if (counter == 3)
            {
                buttons[fourthIndex].GetComponentInChildren<Simon_Says_BTN_Check>().isSafe = true;
            }

            if (counter == 4)
            {
                StartCoroutine(CompletedChallenge());
            }
        }
    }

    public void Randomize()
    {
        firstIndex = Random.Range(0, buttons.Length);
        secondIndex = Random.Range(0, buttons.Length);
        thirdIndex = Random.Range(0, buttons.Length);
        fourthIndex = Random.Range(0, buttons.Length);

        buttons[firstIndex].GetComponentInChildren<Simon_Says_BTN_Check>().value = firstIndex;
        buttons[secondIndex].GetComponentInChildren<Simon_Says_BTN_Check>().value = secondIndex;
        buttons[thirdIndex].GetComponentInChildren<Simon_Says_BTN_Check>().value = thirdIndex;
        buttons[fourthIndex].GetComponentInChildren<Simon_Says_BTN_Check>().value = fourthIndex;
        hasStopped = false;
    }

    public void EndChallengeCheck()
    {
        StartCoroutine(EndChallenge());
    }

    IEnumerator StartChallenge()
    {
        playerLeft = false;
        Randomize();

        if(!playerLeft && !hasSucceeded)
        {
            buttons[firstIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", highLightColor);
            lightUpSFX.Play();
            yield return new WaitForSeconds(.5f);
           
            buttons[firstIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
            yield return new WaitForSeconds(1.5f);
        
            buttons[secondIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", highLightColor);
            lightUpSFX.Play();
            yield return new WaitForSeconds(.5f);
        
            buttons[secondIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
            yield return new WaitForSeconds(1.5f);
        
            buttons[thirdIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", highLightColor);
            lightUpSFX.Play();
            yield return new WaitForSeconds(.5f);
        
            buttons[thirdIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
            yield return new WaitForSeconds(1.5f);
        
            buttons[fourthIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", highLightColor);
            lightUpSFX.Play();
            yield return new WaitForSeconds(.5f);
        
            buttons[fourthIndex].GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        }
    }

    IEnumerator EndChallenge()
    {
        hasFailed = true;
        wrongSFX.Play();

        foreach (Renderer renderer in buttons)
        {
            renderer.GetComponent<Renderer>().material.SetColor("_EmissionColor", failColor);
        }

        yield return new WaitForSeconds(2f);

        foreach (Renderer renderer in buttons)
        {
            renderer.GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        }

        yield return new WaitForSeconds(1f);

        Reset();
        StartCoroutine(StartChallenge());
    }

    IEnumerator CompletedChallenge()
    {
        hasSucceeded = true;
        challengeCompletedSFX.Play();
        completeText.challengeSimonDesc.color = Color.green;

        foreach (Renderer renderer in buttons)
        {
            renderer.GetComponent<Renderer>().material.SetColor("_EmissionColor", successColor);
        }

        portraitPiece.SetActive(true);

        yield return new WaitForSeconds(2f);

        foreach (Renderer renderer in buttons)
        {
            renderer.GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        }

        yield return new WaitForSeconds(1f);
    }
}
