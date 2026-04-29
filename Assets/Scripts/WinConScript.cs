using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConScript : MonoBehaviour
{
    public Collectibles[] collectibles;
    public GameObject YouWinText;
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        
        collectibles = FindObjectsOfType<Collectibles>();
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == collectibles.Length)
        {
            
            YouWinText.SetActive(true);
            YouWinTextTime();
        }
       
    }

    IEnumerable YouWinTextTime()
    {
        yield return new WaitForSeconds(2f);
        YouWinText.SetActive(true);
            YouWinText.SetActive(false);

    }
}
