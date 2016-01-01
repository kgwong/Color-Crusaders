using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {

    public Ship ship;

    bool running = false;

    void Start()
    {
        GetNewShip();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J) && ship)
        {
            ship.ChangeController<PlayerController>();
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
            StartCoroutine("GetNewShipDelay");
        }
    }

    private void GetNewShip()
    {
        GameObject blueFaction = GameObject.Find("BattleManager/Blue Faction");
        Faction factionComponent = blueFaction.GetComponent<Faction>();
        if (factionComponent)
        {
            GameObject randomShip = factionComponent.GetRandomShip();
            if (randomShip)
            {
                ship = randomShip.GetComponent<Ship>();
            }
        }
    }

    IEnumerator GetNewShipDelay()
    {
        if (!running)
        {
            running = true;
            yield return new WaitForSeconds(2f);
            GetNewShip();
            running = false;
        }
    }
}
