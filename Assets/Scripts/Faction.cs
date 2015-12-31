using UnityEngine;
using System.Collections;

public class Faction : MonoBehaviour {

    public GameObject ship;

	void Start ()
    {
        AddShip(ship);
	}
	
	void Update ()
    {
	
	}

    public void AddShip(GameObject ship)
    {
        GameObject test = (GameObject)Instantiate(ship, transform.position, transform.rotation);
        test.transform.parent = this.transform;
    }
}
