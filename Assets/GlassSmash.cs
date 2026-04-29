using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSmash : MonoBehaviour
{
    public AudioSource ASource;
    public AudioClip AClip;
    public GameObject GlassWall;
    public bool WallOff;
    public SpinAttack SA;
    public GameObject SAObject;
    // Start is called before the first frame update
    void Start()
    {
        WallOff = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SpinAttack>())
        {
            
            ASource.PlayOneShot(AClip);
            GlassWall.SetActive(false);
            WallOff = false;

        }
    }
}
