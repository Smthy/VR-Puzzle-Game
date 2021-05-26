using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;

    public int maxHealth = 100, currentHealth, enemyDamage;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);        //Uses a slider so the player can visible see the health
    }

    private void FixedUpdate()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("End Scene");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();           //take damage is set to the enemy damage which will cause the health to lower
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void TakeDamage()
    {
        currentHealth -= enemyDamage;
        SetHealth(currentHealth); //on impact by the AI will cause damage to the player
    }



}
