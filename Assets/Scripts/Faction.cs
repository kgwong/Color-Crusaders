using UnityEngine;
using System.Collections;

public class Faction : MonoBehaviour {

    public enum Color
    {
        RED = 0,
        NEUTRAL = 1,
        BLUE = 2,
        BLACK = 3
    }

    public GameObject ship;
    public Faction.Color color;

    private Minimap minimap;

    public static UnityEngine.Color[] COLOR_DEFINITIONS = new[]
    {
        new UnityEngine.Color(1f, 0.128f, 0f), //RED
        UnityEngine.Color.white, //WHITE
        new UnityEngine.Color(0, 0.297f, 1f), //BLUE,
        UnityEngine.Color.black
    };

    public static UnityEngine.Color ToRGB(Faction.Color color)
    {
        return COLOR_DEFINITIONS[(int)color];
    }

	void Start ()
    {
        minimap = GameObject.Find("Canvas/Minimap").GetComponent<Minimap>();
        for (int i = 0; i < 20; ++i)
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

    public int GetNum()
    {
        return transform.childCount;
    }
}
