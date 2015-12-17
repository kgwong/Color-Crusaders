using UnityEngine;
using System.Collections;

public class BurstFireBlasters : Weapon {

    public GameObject bullet;
    public GameObject bulletTrail;

    void Start () {
	
	}
	
	void Update () {
	
	}

    public override void Fire(GameObject ship)
    {
        GameObject newBullet = (GameObject)Instantiate(bullet, ship.transform.position, ship.transform.rotation);
        GameObject trail = (GameObject)Instantiate(bulletTrail, ship.transform.position, ship.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
    }
}
