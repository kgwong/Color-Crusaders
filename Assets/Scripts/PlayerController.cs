using UnityEngine;
using System.Collections;

public class PlayerController : ShipController
{
    private Ship ship;

    void Start()
    {
        ship = GetComponent<Ship>();
    }

	void Update()
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
        //ship.Rotate(GetRotationFromInput());

        if (Input.GetKey(KeyCode.W))
        {
            ship.Accelerate();
        }

        if (Input.GetKey(KeyCode.K))
        {
            ship.Destroy();
        }
        if(Input.GetKey(KeyCode.A))
        {
            ship.Rotate(ClockDirecton.COUNTER_CLOCKWISE);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ship.Rotate(ClockDirecton.CLOCKWISE);
        }
    }

    private float GetRotationFromInput()
    {
        return -Input.GetAxis("Horizontal");
    }
}
