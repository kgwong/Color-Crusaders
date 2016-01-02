using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

    public GameObject shipExplosion;
    public int maxHealth;

    private int currHealth;

    void Start ()
    {
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
            if (b.GetColor() != gameObject.GetComponent<Ship>().GetColor())
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
