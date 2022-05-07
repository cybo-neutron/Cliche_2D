using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestructibleObject : MonoBehaviour, IDestructible
{

    public int health = 4;
    public EntityType entity_Type = EntityType.Object;
    public EntityType entityType
    {
        get { return entity_Type; }
        set
        {
            entity_Type = value;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Play destroy animation/effect
        Destroy(this.gameObject);
    }
}
