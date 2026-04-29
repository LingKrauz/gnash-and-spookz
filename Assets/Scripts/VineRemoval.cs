using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineRemoval : MonoBehaviour
{
    public GameObject[] GreenBulbsOn;
    public GameObject Vines;
    public GameObject Vines1;

    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == GreenBulbsOn.Length)
        {
            Vines.SetActive (false);
            Vines1.SetActive(false);
        }
       

    }

    public void BulbsActivated()
    {
       for(int i = 0; i < GreenBulbsOn.Length; i++)
        {
          
            
            if(GreenBulbsOn[i].activeInHierarchy)
            {
                counter++;
                //allBulbsOn = true;
                break;
            }
        }
    }
}
