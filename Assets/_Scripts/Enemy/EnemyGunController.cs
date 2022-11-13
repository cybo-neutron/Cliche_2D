using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] int damage;
    [SerializeField] Projectile bulletPrefab;

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.Init(bulletSpeed, damage, ShotBy.Enemy);
    }
}
