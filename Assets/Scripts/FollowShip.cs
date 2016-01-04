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
        Faction playerFaction = battleManager.GetPlayerFaction();
        if (playerFaction == null) return;
        GameObject randomShip = playerFaction.GetRandomShip();
        if (randomShip)
        {
            ship = randomShip.GetComponent<Ship>();
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
