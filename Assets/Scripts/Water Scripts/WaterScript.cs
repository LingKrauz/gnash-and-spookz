using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//First Person Movement in Unity - FPS Controller - YouTube. (n.d.). Retrieved December 3, 2021, from https://www.youtube.com/watch?v=_QajrabyTJc.
public class WaterScript : MonoBehaviour
{

    public AudioSource waterSFX;
    public AudioSource drownSFX;
    public AudioClip splash;
    
    public AudioClip drown;
 
    
    public Player_Jump pJump;
    public CharacterController cController;
    public LayerMask waterLevel;
    public LayerMask groundLevel;
    public Transform onGround;
    public Transform swimLevel;
    public Transform swimLevel2;
    

    public Transform breathCheck;

    public bool playSplash;
    public bool bubblePop;
    public bool bubblePop1;
    public bool bubblePop2;
    public bool bubblePop3;

    public bool isonGround;
    public bool chestInWater;
    public bool feetInWater;
    public bool isunderWater;
    public bool isunderWater2;
    
    public bool drowning;
   
    public bool gravNormal;
    public bool bubbleBreath;
    
    public bool lostBreath;
    public bool lostBreathCheck;

    private float gravityWeight = -9.81f;
    public float waterSurface;
    public float riseDepth;
    
    public float diveDepth;
    
    private float groundReference = 0.4f;
    Vector3 movementDirection;
    public GameObject player;
    public GameObject breathText;
    public GameObject[] breathBubble;


    // Start is called before the first frame update
    public void Start()
    {
        player.GetComponent<NoBreathDamage>().enabled = false;
        gravNormal = false;
        chestInWater = false;
        feetInWater = false;
        isunderWater = false;
       
        lostBreath = false;
        playSplash = true;
        bubbleBreath = true;
    }
    void Update()
    {
        chestInWater = Physics.CheckSphere(swimLevel.position, waterSurface, waterLevel);

        if (chestInWater && !isunderWater)
        {
            if (playSplash)
            {
                WaterSplash();
            }
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<GroundPoundAttack>().enabled = false;
            feetInWater = Physics.CheckSphere(swimLevel2.position, waterSurface, waterLevel);

            pJump.enabled = false;
            gravNormal = false;
            if (feetInWater == true)
            {

                player.GetComponent<Animator>().enabled = false;
                player.GetComponent<GroundPoundAttack>().enabled = false;
                gravityWeight = 0f;

            }

        }
        else if (!chestInWater)
        {
            playSplash = true;
            breathText.SetActive(false);
            lostBreath = false;
          
            isunderWater = false;
            drowning = false;
            bubbleBreath = false;
            gravityWeight = -9.81f;
           
            
        }   
        if (feetInWater == false)
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<GroundPoundAttack>().enabled = true;
        }
        if (!chestInWater && feetInWater && !isunderWater || chestInWater && feetInWater && !isunderWater)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                movementDirection.y = 6.5f;

                gravNormal = true;
                feetInWater = false;

            }
        }
        if(!chestInWater && feetInWater)
        {
            
            player.GetComponent<NoBreathDamage>().cancelDrown();
            
            
            ResetBreathing();
        }

        if (Input.GetKey(KeyCode.LeftControl) && chestInWater || Input.GetKey(KeyCode.LeftControl) && feetInWater)
        {
            
            isunderWater = true;
            movementDirection.y = diveDepth;
            
            cController.Move(movementDirection * Time.deltaTime);
        }
        if (Input.GetMouseButton(1) && chestInWater)
        {
            isunderWater = true;
           
            movementDirection.y = riseDepth;
            cController.Move(movementDirection * Time.deltaTime);
        }
       
        
        if (gravNormal)
        {
            
            cController.Move(movementDirection * Time.deltaTime);
            movementDirection.y += gravityWeight * Time.deltaTime;
            isonGround = Physics.CheckSphere(onGround.position, groundReference, groundLevel);
            if(isonGround == true)
            {
                pJump.enabled = true;

            }
        }
      
        //When the checker for the head to be underwater is set to true, the if statement switches isunderwater2 to true.
        if (drowning)
        {
            
            isunderWater2 = true;
        }
       
        //When the player is underwater is set to true, the if statement then checks if isunderwater2 is true to then switch bubbleBreath to true.
        if (isunderWater)
        {
            drowning = Physics.CheckSphere(breathCheck.position, waterSurface, waterLevel);
            breathText.SetActive(true);
            player.GetComponent<NoBreathDamage>().startDrown();
            if (isunderWater2)
            {
                bubbleBreath = true;
            }
           
        }
        if(pJump.enabled == true)
        {
            gravNormal = false;
            chestInWater = false;
            feetInWater = false;
        }
       //If bubbleBreath is true it runs the UnderwaterBreathing Method.
        if (bubbleBreath)
        {
            UnderWaterBreathing();
        }
        if (lostBreath)
        {
            isunderWater2 = false;
            NoBreath();
        }
    }
    public void WaterSplash()
    {
        playSplash = false;
        waterSFX.PlayOneShot(splash);
         bubblePop = true;
      

    }
    public void BubblePop()
    {
        bubblePop1 = true;
        bubblePop = false;
        drownSFX.Play();
        

    }
    public void BubblePop1()
    {
        bubblePop1 = false;
        drownSFX.Play();
        bubblePop2 = true;

    }
    public void BubblePop2()
    {
        bubblePop2 = false;
        drownSFX.Play();
        bubblePop3 = true;

    }
    public void BubblePop3()
    {
        bubblePop3 = false;
        drownSFX.Play();


    }


    //The UnderWaterBreathing method runs a StartCoroutine method which runs a LoseBreath IEnumerator Method.
    public void UnderWaterBreathing()
    {
        StartCoroutine(LoseBreath());
    }
    
    //When the LoseBreath for loop sets the lostBreath boolean to true, the if statement inside runs.
    public void NoBreath()
    {
        player.GetComponent<NoBreathDamage>().enabled = true;
       
    }
    //This Method runs a For Loop which sets the GameObject arrays to false.
    //This Method then check if the index is equal to 3, if so it sets lostBreath boolean to true.
    IEnumerator LoseBreath()
    {
        
        
        if (isunderWater == true)
        {
           
            for (int i = 0; i < breathBubble.Length; i++)
            {
                yield return new WaitForSeconds(2f);
                breathBubble[i].SetActive(false);
                if (bubblePop)
                {
                    BubblePop();
                }
                else if (bubblePop1)
                {
                    BubblePop1();
                }
                else if(bubblePop2)
                {
                    BubblePop2();
                }
                else if(bubblePop3)
                {
                    BubblePop3();
                }

                if (isunderWater == false)
                {
                   
                    break;
                }
                
                if (i == 3)
                {
                   
                    lostBreath = true;
                    break;
                }
            }
        }
    }
    
    public void ResetBreathing()
    {

        foreach (GameObject breaPoints in breathBubble)
        {
            breaPoints.SetActive(true);
        }
       
        
    }

}
