using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

    void Start () {
	
	}

    void Update () {
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Projectile"))
        {
            Debug.Log("got hit by projectile!");
        }
    }

}
