using UnityEngine;
using System.Collections;

public class PlayerController : ShipController {

	public override void ControllerUpdate(Ship ship)
    {
        if (Input.GetMouseButton(0))
        {
            ship.primaryWeapon.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ship.primaryWeapon.Fire();
        }
        if (Input.GetMouseButton(1))
        {
            ship.secondaryWeapon.Fire();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            ship.Decelerate();
        }
        ship.Rotate(-Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.W))
        {
            ship.Accelerate();
        }

        if (Input.GetKey(KeyCode.K))
        {
            ship.Destroy();
        }

    }
}
