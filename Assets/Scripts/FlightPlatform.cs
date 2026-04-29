using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//First Person Movement in Unity - FPS Controller - YouTube. (n.d.). Retrieved December 3, 2021, from https://www.youtube.com/watch?v=_QajrabyTJc.
public class FlightPlatform : MonoBehaviour
{
    public CharacterController cController;
    public GameObject player;
    public Animator pAnim;

    public AudioSource flySFX;
    public AudioClip flyingSFX;
    
        public bool canFly;
    public bool nowFlying;
    public bool gotLaunched;
    public float gravityWeight = 0f;
   Vector3 launchStrength;

    public LayerMask theGound;
    public bool onGground;
    public Transform isonGrounded;
    public float groundReference;

    

    // Start is called before the first frame update
    void Start()
    {
        onGground = false;
        canFly = false;
        nowFlying = false;
        gotLaunched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canFly== true && nowFlying== true)
        {
            Launch();
            gotLaunched = true;
            StartCoroutine(FlightOff());
        }
        if (onGground == true)
        {
            
            nowFlying = false;
            gotLaunched = false;
            player.GetComponent<Player_Jump>().enabled = true;

        }

        if (gotLaunched == true)
        {
            
            player.GetComponent<Player_Jump>().enabled = false;
            gravityWeight = 0f;
            
            
        }
        if(Input.GetMouseButton(1) && gotLaunched == true)
        {
            
            launchStrength.y = 10f;
            cController.Move(launchStrength * Time.deltaTime);
            GameObject.Find("AudioSource").GetComponent<AudioController>().PlayFlapping();
        }
        if (Input.GetKey(KeyCode.LeftControl)&& gotLaunched == true)
        {
            onGground = Physics.CheckSphere(isonGrounded.position, groundReference, theGound);
            launchStrength.y = -10f;
            cController.Move(launchStrength * Time.deltaTime);
            
        }

    }


    private void OnTriggerStay(Collider other)
    {
        canFly = true;
        onGground = false;
        if (other.tag == "Flight Platform")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                flySFX.PlayOneShot(flyingSFX);
                nowFlying = true;
               
            }
            
           
        }
    }
    

    private void Launch()
    {   
        if (nowFlying == true)
        {
            
            launchStrength.y = 8f;
            cController.Move(launchStrength * Time.deltaTime);
            

        }
       
    }
    IEnumerator FlightOff()
    {
        yield return new WaitForSeconds(1f);
        
        nowFlying = false;
    }

}
