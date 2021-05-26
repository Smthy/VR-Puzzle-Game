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
        {                                                       //Using the axe to break the crate to allow access to it, makes the player work for the key
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
