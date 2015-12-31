using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {

    public Ship ship;

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            ship.ChangeController<PlayerController>();
        }
    }

	void LateUpdate ()
    {
        transform.position = new Vector3(ship.transform.position.x,
                                        ship.transform.position.y,
                                        ship.transform.position.z - 10);
    }
}
