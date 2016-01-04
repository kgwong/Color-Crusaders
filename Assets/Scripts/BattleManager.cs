using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

    public GameObject ship;

    public FactionEditor factionEditor;

    public Faction faction;
    public Minimap minimap;

	void Start ()
    {
        for (int i = 0; i < 8; ++i)
        {
            AddFaction(factionEditor.GetSettings(i));
        }
	}
	
	void Update ()
    {
	
	}

    public void Restart()
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 8; ++i)
        {
            AddFaction(factionEditor.GetSettings(i));
        }
    }


    public void AddFaction(FactionEditor.Settings settings)
    {
        if (settings.enabled && settings.numUnits > 0)
        {
            AddFaction(settings.color, settings.numUnits, settings.name);
        }
    }

    public void AddFaction(Color color, int size, string optionalName = null)
    {
        Faction newFaction = Instantiate(faction);
        newFaction.transform.SetParent(this.transform);
        newFaction.ship = ship;
        newFaction.minimap = minimap;
        newFaction.name = optionalName;
        newFaction.color = color;

        newFaction.Spawn(size);
    }

    public GameObject GetClosestTargetFor(GameObject ship)
    {
        Ship s = ship.GetComponent<Ship>();
        Faction shipFaction = s.GetFaction();

        GameObject closest = null;
        float closestDistSquared = 0;

        foreach (Transform child in transform)
        {
            Faction f = child.GetComponent<Faction>();
            if (f != shipFaction)
            {
                foreach (Transform fship in f.transform)
                {
                    if (closest == null)
                    {
                        closest = fship.gameObject;
                        closestDistSquared = UsefulMath.DistSquared2D(ship.transform.position, closest.transform.position);
                    }
                    else
                    {
                        float newDistSquared = UsefulMath.DistSquared2D(ship.transform.position, fship.transform.position);
                        if (newDistSquared < closestDistSquared)
                        {
                            closest = fship.gameObject;
                            closestDistSquared = newDistSquared;
                        }
                    }
                }
            }
        }
        return closest;
    }

    /*public GameObject GetRandomTargetFor(GameObject ship)
    {
        Ship s = ship.GetComponent<Ship>();
        Faction faction = s.GetFaction();
        if (faction == blueFaction)
        {
            return redFaction.GetRandomShip();
        }
        else
        {
            return blueFaction.GetRandomShip();
        }
    }*/
    
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

    //Returns the Faction with the most numbers. If the top factions
    //are tied, return null;
    public Faction GetWinningFaction()
    {
        Faction winning = null;
        int max = 0;
        bool unique = true; //flag is false if there is a tie.

        foreach (Transform child in transform)
        {
            Faction f = child.GetComponent<Faction>();
            if (f.GetNum() > max)
            {
                winning = f;
                max = f.GetNum();
                unique = true;
            }
            else if (f.GetNum() == max)
            {
                unique = false;
            }
        }

        return unique ? winning : null;
    }

    public int GetTotalShips()
    {
        int sum = 0;
        foreach (Transform child in transform)
        {
            Faction f = child.GetComponent<Faction>();
            sum += f.GetNum();
        }
        return sum;
    }

    public Faction GetPlayerFaction()
    {
        if (transform.childCount == 0)
        {
            return null;
        }
        return transform.GetChild(0).GetComponent<Faction>();
    }
}
