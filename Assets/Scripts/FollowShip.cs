using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {

    public Ship ship;
    public BattleManager battleManager;

    bool running = false;
    bool initialized = false;

    void Start()
    {   
    }

    void Update()
    {
        if (!initialized)
        {
            GetNewShip();
            initialized = true;
        }
    }

    void LateUpdate()
    {
        if (ship)
        {
            transform.position = new Vector3(ship.transform.position.x,
                                            ship.transform.position.y,
                                            ship.transform.position.z - 10);
        }
        else
        {
            StartCoroutine("GetNewShipDelay", 2f);
        }
    }

    public Ship GetCurrentShip()
    {
        return enabled ? ship : null;
    }

    public IEnumerator GetNewShipDelay(float seconds)
    {
        if (!running)
        {
            running = true;
            yield return new WaitForSeconds(seconds);
            GetNewShip();
            running = false;
        }
    }

    public void GetNewShip()
    {
        enabled = true;
        Faction playerFaction = battleManager.GetPlayerFaction();
        if (playerFaction == null) return;
        GameObject randomShip = playerFaction.GetRandomShip();
        if (randomShip)
        {
            ship = randomShip.GetComponent<Ship>();
        }
    }
}
