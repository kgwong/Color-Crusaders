using UnityEngine;
using System.Collections;

public class Faction : MonoBehaviour {

    public GameObject ship;
    public Color color;

    public Minimap minimap;

	void Start ()
    {
	}
	
	void Update ()
    {
    }

    public void Spawn(int n)
    {
        for (int i = 0; i < n; ++i)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0f);
            AddShip(ship, randomPosition);
        }
    }

    public void AddShip(GameObject ship, Vector3 position)
    {
        GameObject newShip = (GameObject)Instantiate(ship, position, transform.rotation);
        newShip.transform.parent = this.transform;
        Ship shipComponent = newShip.GetComponent<Ship>();
        shipComponent.SetFaction(this);
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

    public int GetNum()
    {
        return transform.childCount;
    }

    public Color GetRGB()
    {
        return color;
    }
}
