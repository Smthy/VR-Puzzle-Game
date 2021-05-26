using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public float swordDamage = 35f, axeDamage = 20f;

    private void Update()
    {
        if(health <= 0f)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {   
            health -= swordDamage;                      //uses collisions to identify which weapon has struck the damage
        }

        if (other.CompareTag("Axe"))
        {
            health -= axeDamage;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
