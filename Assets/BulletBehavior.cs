using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public float lifetime;
    public int damage;

	void Start ()
    {
        Invoke("Die", lifetime);
	}
	
	void Update ()
    {
	
	}

    private void Die()
    {
        Destroy(gameObject);
    }
}
