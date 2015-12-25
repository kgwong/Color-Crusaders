using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public GameObject explosionParticles;

    public float lifetime;
    public int damage;

    private Color color;

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
            Color otherColor = collider.gameObject.GetComponent<Ship>().GetColor();
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

    public void SetColor(Color color)
    {
        this.color = color;
    }

    public Color GetColor(Color color)
    {
        return color;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
