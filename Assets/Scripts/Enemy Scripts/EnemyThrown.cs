using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrown : MonoBehaviour
{
    public bool isThrown =false;
    public GameObject isCollider;
    public GameObject Partent;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isThrown == true)
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
            }

            if (other.gameObject != Partent)
            {
                
                Destroy(Partent);
            }

           
        }



    }

}
