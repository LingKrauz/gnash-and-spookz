using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Mitchell Kraus 12/12/21

public class InputPlatform : MonoBehaviour
{
    [SerializeField]
    private bool isActivated;

    public Material transparentMat;

    public Material opaqueMat;

    private Collider platCollider;

    private bool isDelayed = false;


    // Start is called before the first frame update
    void Start()
    {
        platCollider = GetComponent<Collider>();

        if (!isActivated)
        {
            this.GetComponent<MeshRenderer>().material = transparentMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isDelayed)
            {
                StartCoroutine(timer());
                isDelayed = true;
            }
        }
    }

    //Ape code below... Idk how to delay the code in any other way though
    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.5f);
        isActivated = !isActivated;
        if (!isActivated)
        {
            this.GetComponent<MeshRenderer>().material = transparentMat;
            platCollider.enabled = false;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = opaqueMat;
            platCollider.enabled = true;
        }
        isDelayed = false;
    }
}
