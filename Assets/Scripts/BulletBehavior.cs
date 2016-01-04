using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public GameObject explosionParticles;

    public float lifetime;
    public int damage;

    private GameObject originShip;
    private Faction faction;

	void Start ()
    {
        Destroy(gameObject, lifetime);
    }
	
	void Update ()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ship"))
        {
            Faction otherFaction = collider.gameObject.GetComponent<Ship>().GetFaction();
            if (otherFaction != this.faction) 
            {
                Destroy(gameObject);
                Instantiate(explosionParticles, transform.position, transform.rotation);
            }
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetOriginShip(GameObject ship)
    {
        originShip = ship;
        //need to store faction separately because the ship 
        //may have been destroyed before the bullet
        faction = ship.GetComponent<Ship>().GetFaction();
    }

    public GameObject GetOriginShip()
    {
        return originShip;
    }

    public Faction GetFaction()
    {
        return faction;
    }

}
