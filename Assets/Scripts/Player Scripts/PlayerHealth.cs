using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private bool isDead;
    
    public static int lives = 1;
    public HealthBar healthBar;
    public GameOverMenu goMenu;
    public AudioController audioCue;
    public SkinnedMeshRenderer meshRend;
    public Material damagedMat;
    public Material normalMat;
    public float damageTimerSet;
    private float damageTimer;
    private bool isDamaged;
    public Animator pAnim;

    public static bool isInCutscene;
    void Start()
    {
        lives = PlayerPrefs.GetInt("PlayerLives");

        if (PlayerPrefs.HasKey("PlayerMaxHealth"))
        {
            maxHealth = PlayerPrefs.GetFloat("PlayerMaxHealth");
        }

        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
        healthBar.livesCount.text = PlayerPrefs.GetInt("PlayerLives").ToString();
        //audioCue = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    void Update()
    {
        if (isDamaged)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                meshRend.material = normalMat;
                isDamaged = false;
            }
        }

    }
    
    public void DamageHealth(float damage)
    {
        if(!isDead && !isInCutscene)
        {
            if(damage > 0)
            {
                audioCue.PlayHurt();
                damageTimer = damageTimerSet;
                meshRend.material = damagedMat;
                isDamaged = true;

            }

            health -= damage;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            else if(health < 0)
            {
                health = 0;
            }
            //ResetAbilities.ResetAbility();
            healthBar.UpdateHealthBar(health, maxHealth);
            HealthCheck();
        }
        PlayerPrefs.SetFloat("PlayerMaxHealth", maxHealth);
    }

    public void HealthCheck()
    {
        if(!isDead)
        {
            if(health <= 0)
            {
                isDead = true;
                LivesCount();
            }    
        }
    }

    public void LivesCount()
    {
        if (isDead)
        {
            lives--;
            PlayerMovement.canMove = false;
            PlayerPrefs.SetInt("PlayerLives", lives);
            pAnim.SetBool("isDead", true);
        }
    }

    public void RespawnCheck()
    {
        if (lives <= 0)
        {
            goMenu.GameOver();
            PlayerPrefs.SetInt("PlayerLives", 1);
        }

        else
        {
            isDead = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
