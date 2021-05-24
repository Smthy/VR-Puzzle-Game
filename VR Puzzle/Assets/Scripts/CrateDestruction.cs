using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestruction : MonoBehaviour
{
    public int health;
    public int axeDamage;

    public ParticleSystem breakage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Axe"))
        {
            damageImpact();
        }
    }

    void damageImpact()
    {
        if(health  > 0)
        {
            health = health - axeDamage;
            breakage.Play();
        }
        
        else if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
