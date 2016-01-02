using UnityEngine;
using System.Collections;

public class DoubleBlasters : Weapon
{
    public GameObject bullet;

    public float fireRate;
    public float distanceBetweenShots;

    private float cooldownTimer;


    void Start()
    {
        cooldownTimer = fireRate;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public override void Fire()
    {
        if (cooldownTimer <= 0)
        {
            ShootProjectile(bullet, transform.position + transform.right * distanceBetweenShots, transform.rotation, 1000);
            ShootProjectile(bullet, transform.position - transform.right * distanceBetweenShots, transform.rotation, 1000);
            cooldownTimer = fireRate;
        }
    }
}
