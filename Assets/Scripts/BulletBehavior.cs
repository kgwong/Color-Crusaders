using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public GameObject explosionParticles;

    public float lifetime;
    public int damage;

    private GameObject originShip;
    private Faction.Color color;

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
            Faction.Color otherColor = collider.gameObject.GetComponent<Ship>().GetColor();
            if (otherColor != this.color) 
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
        //need to store color separately because the ship 
        //may have been destroyed before the bullet
        color = ship.GetComponent<Ship>().GetColor();
    }

    public GameObject GetOriginShip()
    {
        return originShip;
    }

    public Faction.Color GetColor()
    {
        return color;
    }

}
