using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillConfirm : MonoBehaviour
{
    public Enemy[] EnemyArray;
    public int EnemyCount;
    public bool enemcount = false;
    public DialogScript dScript;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        dScript = FindObjectOfType<DialogScript>();
        EnemyArray = FindObjectsOfType<Enemy>();
        EnemyCount = EnemyArray.Length;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyArray = FindObjectsOfType<Enemy>();
        if (EnemyCount > EnemyArray.Length && enemcount == false)
        {
            
            dScript.DisplayDialog("This type of enemy is the one we need to defeat for the cursed cagest to unlock!");
            enemcount = true;
        }
        
    }

   
}
