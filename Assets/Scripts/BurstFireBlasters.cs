using UnityEngine;
using System.Collections;

public class BurstFireBlasters : Weapon {

    public GameObject bullet;

    public float fireRate;

    public int burstSize;
    public float timeBetweenBursts;

    private int burstCount = 0;
    private float cooldownTimer = 0.0f;

    void Start ()
    {
        burstCount = burstSize;
	}
	
	void Update ()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public override void Fire()
    {
        if (cooldownTimer <= 0.0f)
        {
            StartCoroutine("BurstFire");
            cooldownTimer = timeBetweenBursts;
        }
    }

    private IEnumerator BurstFire()
    {
        while (burstCount > 0)
        {
            float variation = VariationFromAccuracy(accuracy); ;
            float random = Random.Range(-variation, variation);
            Quaternion finalRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + random);

            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, finalRotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
            newBullet.GetComponent<BulletBehavior>().SetColor(color);
            --burstCount;
            yield return new WaitForSeconds(fireRate);
        }
        burstCount = burstSize;
    }
}
