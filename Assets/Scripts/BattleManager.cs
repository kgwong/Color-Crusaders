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

    public GameObject GetClosestTargetFor(GameObject ship)
    {
        Ship s = ship.GetComponent<Ship>();
        Faction.Color color = s.GetColor();
        if (color == Faction.Color.BLUE)
        {
            return GetClosestTargetFromFaction(ship, redFaction);
        }
        else
        {
            return GetClosestTargetFromFaction(ship, blueFaction);
        }
    }

    public GameObject GetRandomTargetFor(GameObject ship)
    {
        Ship s = ship.GetComponent<Ship>();
        Faction.Color color = s.GetColor();
        if (color == Faction.Color.BLUE)
        {
            return redFaction.GetRandomShip();
        }
        else
        {
            return blueFaction.GetRandomShip();
        }
    }
    
    private GameObject GetClosestTargetFromFaction(GameObject ship, Faction f)
    {
        GameObject closest = null;
        float closestDistSquared = 0;
        foreach (Transform child in f.transform)
        {
            if (closest == null)
            {
                closest = child.gameObject;
                closestDistSquared = UsefulMath.DistSquared2D(ship.transform.position, closest.transform.position);
            }
            else
            {
                float newDistSquared = UsefulMath.DistSquared2D(ship.transform.position, child.transform.position);
                if (newDistSquared < closestDistSquared)
                {
                    closest = child.gameObject;
                    closestDistSquared = newDistSquared;
                }
            }
        }
        return closest;
    }
}
