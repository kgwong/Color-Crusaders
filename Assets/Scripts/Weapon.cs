using UnityEngine;
using System.Collections;

abstract public class Weapon : MonoBehaviour {

    //How many degrees clockwise and counterclockwise the weapon can aim. 0 Means the weapon cannot be aimed. 
    public float degreesAim;

    //A float from 0 to 1 denoting how the weapon firing can fluctuate
    public float accuracy = 1;
    protected Ship.ShipColor color;

    public static float VariationFromAccuracy(float accuracy)
    {
        return 50 * (1 - accuracy);
    }

    public abstract void Fire();

    public void SetColor(Ship.ShipColor color)
    {
        this.color = color;
    }

    public Ship.ShipColor GetColor()
    {
        return color;
    }

    public void Aim(Vector3 target)
    {
        Vector3 diff = target - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (transform.localEulerAngles.z > degreesAim && transform.localEulerAngles.z < 180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 20f + transform.parent.eulerAngles.z);
        }
        if (transform.localEulerAngles.z < (360 - degreesAim) && transform.localEulerAngles.z >= 180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 340f + transform.parent.eulerAngles.z);
        }
    }
}
