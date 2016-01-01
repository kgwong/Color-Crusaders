using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

    public Faction redFaction;
    public Faction blueFaction;

	void Start ()
    {
	}
	
	void Update ()
    {
	
	}

    public GameObject GetRandomTargetFor(GameObject ship)
    {
        Ship s = ship.GetComponent<Ship>();
        Ship.ShipColor color = s.GetColor();
        if (color == Ship.ShipColor.BLUE)
        {
            return redFaction.GetRandomShip();
        }
        else
        {
            return blueFaction.GetRandomShip();
        }
    }
}
