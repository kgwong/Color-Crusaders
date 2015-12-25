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
            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position + transform.right * distanceBetweenShots, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
            newBullet.GetComponent<BulletBehavior>().SetColor(color);

            GameObject newBullet2 = (GameObject)Instantiate(bullet, transform.position - transform.right * distanceBetweenShots, transform.rotation);
            newBullet2.GetComponent<Rigidbody2D>().AddForce(newBullet2.transform.up * 1000);
            newBullet2.GetComponent<BulletBehavior>().SetColor(color);

            cooldownTimer = fireRate;
        }
    }
}
