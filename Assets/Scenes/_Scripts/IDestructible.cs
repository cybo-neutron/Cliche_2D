using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Type of object
// help ful in detecting whether a bullet should hit an entity or not.
public enum EntityType
{
    Player,
    Enemy,
    Object
}

public interface IDestructible
{
    public EntityType entityType { get; set; }

    public void TakeDamage(int damage);

    public void Die();
}
