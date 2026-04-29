using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenShuttOff : MonoBehaviour
{
    //public GameObject WinText;
    public GameObject sceneChief;
    // Start is called before the first frame update
    void Start()
    {
        //WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator WaitForTime()
    {

        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetString("CurrLevelName", SceneManager.GetActiveScene().name);
        sceneChief.SetActive(false);
        
        SceneManager.LoadScene(7);
    }
}
