using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public GameObject explosionParticles;

    public float lifetime;
    public int damage;

    private Ship.ShipColor color;

	void Start ()
    {
        Invoke("Die", lifetime);
	}
	
	void Update ()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ship"))
        {
            Ship.ShipColor otherColor = collider.gameObject.GetComponent<Ship>().GetColor();
            if (otherColor != color)
            {
                Die();
            }
        }
    }

    void OnDestroy()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
    }

    public void SetColor(Ship.ShipColor color)
    {
        this.color = color;
    }

    public int GetDamage()
    {
        return damage;
    }

    public Ship.ShipColor GetColor()
    {
        return color;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
