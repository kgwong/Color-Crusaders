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
        if (GameInputManager.GetMouseButton(0))
        {
            ship.primaryWeapon.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ship.primaryWeapon.Fire();
        }
        if (GameInputManager.GetMouseButton(1))
        {
            ship.secondaryWeapon.Fire();
        }

        if (GameInputManager.GetKey(KeyCode.Space) || GameInputManager.GetKey(KeyCode.S))
        {
            ship.Decelerate();
        }
        if (GameInputManager.GetKey(KeyCode.W))
        {
            ship.Accelerate();
        }

        if (GameInputManager.GetKey(KeyCode.K))
        {
            ship.Destroy();
        }
        if(GameInputManager.GetKey(KeyCode.A))
        {
            ship.Rotate(ClockDirecton.COUNTER_CLOCKWISE);
        }
        if (GameInputManager.GetKey(KeyCode.D))
        {
            ship.Rotate(ClockDirecton.CLOCKWISE);
        }
    }

    void OnDestroy()
    {
        Camera mainCam = Camera.main;
        if (mainCam)
        {
            PlayerCameraControl playerCameraControl = mainCam.gameObject.GetComponent<PlayerCameraControl>();
            if (playerCameraControl)
                playerCameraControl.SetSpectatorMode(true);
        }
    }
}
