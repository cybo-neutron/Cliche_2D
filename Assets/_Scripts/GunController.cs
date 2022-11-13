using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] int damage;
    [SerializeField] Projectile bulletPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.Init(bulletSpeed, damage, ShotBy.Player);
    }
}
