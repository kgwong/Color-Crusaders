using UnityEngine;
using System.Collections;
using System;

public class BasicAIController : ShipController
{
    public float aimDistance = 5.0f;
    public GameObject target;

    private Ship ship;

    private BattleManager battleManager;

    void Start()
    {
        ship = GetComponent<Ship>();
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }


    void Update()
    {
        if (target == null)
        {
            ChangeTarget(GetNewTarget());
            if (target == null)
            {
                return;
            }
        }

        Vector3 diff = target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
        float relativeRotation = UsefulMath.NormalizeAngle360(rotationZ - transform.eulerAngles.z);

        if (UsefulMath.IsBetween(relativeRotation, 0, 180))
        {
           ship.Rotate(ClockDirecton.COUNTER_CLOCKWISE);
        }
        else if (UsefulMath.IsBetween(relativeRotation, 180, 360))
        {
            ship.Rotate(ClockDirecton.CLOCKWISE);
        }

        float aimBound1, aimBound2;
        if (ship.primaryWeapon.degreesAim == 0f)
        {
            aimBound1 = 0 + 20f;
            aimBound2 = 360 - 20f;
        }
        else
        {
            aimBound1 = 0 + (ship.primaryWeapon.degreesAim);
            aimBound2 = 360 - (ship.primaryWeapon.degreesAim);
        }

        if ( ! UsefulMath.IsBetween(relativeRotation, aimBound1, aimBound2))
        {
            if (InRange(target.transform.position))
            {
                ship.primaryWeapon.Aim(target.transform.position);
                ship.primaryWeapon.Fire();
            }
        }
        ship.Accelerate();
    }

    //Called by SendMessage 
    void OnAttacked(GameObject projectile)
    {
        BulletBehavior bulletComponent = projectile.GetComponent<BulletBehavior>();
        if (bulletComponent)
        {
            ChangeTarget(bulletComponent.GetOriginShip()); 
        }
    }

    private bool InRange(Vector3 target)
    {
        return UsefulMath.DistSquared2D(transform.position, target) < Mathf.Pow(aimDistance, 2);
    }

    private GameObject GetNewTarget()
    {
        //return battleManager.GetRandomTargetFor(gameObject);
        return battleManager.GetClosestTargetFor(gameObject);
    }

    private void ChangeTarget(GameObject newTarget)
    {
        target = newTarget;
    }

}
