using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpear : MonoBehaviour
{
    public GameObject SpearPoint;
    public GameObject player;
    public AudioSource horn1;
    public AudioSource horn2;
    public AudioSource horn3;
    public AudioSource horn4;
    public AudioSource horn5;

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
        if (other.tag == "Player")
        {
            StartCoroutine(parentAttach());
            other.GetComponent<PlayerHealth>().DamageHealth(1);
            int RNG = Random.Range(1, 5);
            if (RNG == 1)
            {
                horn1.Play();
            }
            else if (RNG == 2)
            {
                horn2.Play();
            }
            else if (RNG == 3)
            {
                horn5.Play();
            }
            else if (RNG == 4)
            {
                horn4.Play();
            }
            else if (RNG == 5)
            {
                horn3.Play();
            }
        }
        IEnumerator parentAttach()
        {

            player.transform.parent = SpearPoint.transform;
            yield return new WaitForSeconds(1f);
            player.transform.parent = null;
        }
    }
}
