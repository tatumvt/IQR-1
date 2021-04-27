using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public float lazerDamage;
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<enemyMove>().TakeDamage(lazerDamage);
        }
    }
}
