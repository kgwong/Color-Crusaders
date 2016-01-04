using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

    public GameObject shipExplosion;
    public int maxHealth;

    private int currHealth;

    private Faction faction;

    void Start ()
    {
        faction = GetComponent<Ship>().GetFaction();
        currHealth = maxHealth;
	}

    void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Projectile"))
        {
            BulletBehavior b = collider.gameObject.GetComponent<BulletBehavior>();
            if (b.GetFaction() != this.faction)
            {
                TakeDamage(b.GetDamage());
                SendMessage("OnAttacked", collider.gameObject, SendMessageOptions.DontRequireReceiver);
            }

        }
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(shipExplosion, transform.position, Quaternion.identity);
    }

}
