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

        limitedMouseAim(20.0f);
        /*Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);    
        if (transform.localEulerAngles.z > 20 && transform.localEulerAngles.z < 180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 20f + transform.parent.eulerAngles.z);
        }
        if (transform.localEulerAngles.z < 340 && transform.localEulerAngles.z >= 180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 340f + transform.parent.eulerAngles.z);
        }*/
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
            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
            newBullet.GetComponent<BulletBehavior>().SetColor(color);
            --burstCount;
            yield return new WaitForSeconds(fireRate);
        }
        burstCount = burstSize;
    }
}
