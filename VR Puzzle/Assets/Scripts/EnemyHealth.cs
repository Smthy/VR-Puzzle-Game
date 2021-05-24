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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            health -= swordDamage;
        }

        if (collision.gameObject.CompareTag("Axe"))
        {
            health -= axeDamage;
        }


    }

    void Die()
    {
        Destroy(gameObject);
    }
}
