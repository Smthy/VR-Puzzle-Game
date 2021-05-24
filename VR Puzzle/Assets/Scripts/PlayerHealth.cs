using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;

    public int maxHealth = 100, currentHealth, enemyDamage;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            //Player Will Die;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
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
