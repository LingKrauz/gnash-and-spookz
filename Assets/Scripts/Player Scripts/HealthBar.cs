using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth playerHealth;
    public Text livesCount;
    public Animator hudAnim;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.minValue = 0.001f;
        healthBar.value = playerHealth.health;
        livesCount.text = PlayerHealth.lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        hudAnim.SetBool("makeVisible", true);
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        healthText.text = (currentHealth.ToString() + " / " + maxHealth.ToString());
    }

    public void UpdateLives(int lives)
    {
        hudAnim.SetBool("makeVisible", true);
        livesCount.text = lives.ToString();
    }

    public void ResetVisibleBool()
    {
        hudAnim.SetBool("makeVisible", false);
    }    




}
