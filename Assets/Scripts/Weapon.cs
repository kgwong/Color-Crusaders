using UnityEngine;
using System.Collections;

abstract public class Weapon : MonoBehaviour {

    protected Ship.ShipColor color;

    public abstract void Fire();

    public void SetColor(Ship.ShipColor color)
    {
        this.color = color;
    }

    public Ship.ShipColor GetColor()
    {
        return color;
    }

    protected void limitedMouseAim(float degrees)
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (transform.localEulerAngles.z > degrees && transform.localEulerAngles.z < 180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 20f + transform.parent.eulerAngles.z);
        }
        if (transform.localEulerAngles.z < (360 - degrees) && transform.localEulerAngles.z >= 180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 340f + transform.parent.eulerAngles.z);
        }
    }
}
