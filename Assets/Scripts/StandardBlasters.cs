using UnityEngine;
using System.Collections;

public class StandardBlasters : Weapon
{
    public GameObject bullet;

    public float fireRate;

    private float cooldownTimer;


    void Start()
    {
        cooldownTimer = fireRate;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        limitedMouseAim(20.0f);
    }

    public override void Fire()
    {
        if (cooldownTimer <= 0)
        {
            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
            newBullet.GetComponent<BulletBehavior>().SetColor(color);

            cooldownTimer = fireRate;
        }
    }
}
