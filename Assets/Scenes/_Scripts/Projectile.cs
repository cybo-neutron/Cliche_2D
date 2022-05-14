using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotBy
{
    Player,
    Enemy
}


public class Projectile : MonoBehaviour
{
    float bulletSpeed;
    int damageAmount;
    ShotBy shotBy;


    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    public void Init(float _bulletSpeed, int _damageAmount, ShotBy _shotBy = ShotBy.Enemy)
    {
        bulletSpeed = _bulletSpeed;
        damageAmount = _damageAmount;
        shotBy = _shotBy;
        Destroy(this.gameObject, 4f);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider != null)
        {
            IDestructible hit;
            bool didHitObj = other.gameObject.TryGetComponent<IDestructible>(out hit);
            if (didHitObj)
            {
                if (hit.entityType == EntityType.Object || (hit.entityType == EntityType.Enemy && shotBy == ShotBy.Player) || (hit.entityType == EntityType.Player && shotBy == ShotBy.Enemy))
                    hit.TakeDamage(damageAmount);
            }

            Destroy(this.gameObject);
        }

    }
}
