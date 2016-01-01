using UnityEngine;
using System.Collections;

public class Faction : MonoBehaviour {

    public GameObject ship;
    public Ship.ShipColor color;

    private Minimap minimap;

	void Start ()
    {
        minimap = GameObject.Find("Canvas/Minimap").GetComponent<Minimap>();
        for (int i = 0; i < 100; ++i)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0f);
            AddShip(ship, randomPosition);
        }
	}
	
	void Update ()
    {
    }

    public void AddShip(GameObject ship, Vector3 position)
    {
        GameObject newShip = (GameObject)Instantiate(ship, position, transform.rotation);
        newShip.transform.parent = this.transform;
        Ship shipComponent = newShip.GetComponent<Ship>();
        shipComponent.SetColor(color);

        minimap.AddDot(newShip);
    }

    public GameObject GetRandomShip()
    {
        if (transform.childCount == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, transform.childCount);
        return transform.GetChild(randomIndex).gameObject;
    }
}
