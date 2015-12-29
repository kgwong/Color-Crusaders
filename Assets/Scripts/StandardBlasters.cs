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
    }

    public override void Fire()
    {
        if (cooldownTimer <= 0)
        {
            float variation = VariationFromAccuracy(accuracy); ;
            float random = Random.Range(-variation, variation);
            Quaternion finalRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + random);

            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, finalRotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
            newBullet.GetComponent<BulletBehavior>().SetColor(color);

            cooldownTimer = fireRate;
        }
    }
}
