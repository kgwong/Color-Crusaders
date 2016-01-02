using UnityEngine;
using System.Collections;

public class UsefulMath : MonoBehaviour {
    //A class of static math-y functions that aren't actually 
    //very useful...

    //exclusive
    public static bool IsBetween(float value, float lower, float upper)
    {
        return value > lower && value < upper;
    }

    //returns an equivalent angle between 0 and 360
    //counter clockwise is ascending, clockwise is descending
    public static float NormalizeAngle360(float degrees)
    {
        float temp = degrees % 360;
        if (temp < 0)
        {
            temp += 360;
        }
        return temp;
    }

    public static float DistSquared2D(Vector3 a, Vector3 b)
    {
        return Mathf.Pow(b.x - a.x, 2) +
                Mathf.Pow(b.y - a.y, 2);
    }

    public static Vector2 ToFracCoord(Vector2 coord, float maxX, float maxY)
    {
        return new Vector2(coord.x / maxX, coord.y / maxY);
    }


    public static Vector2 ToAbsCoord(Vector2 frac, float maxX, float maxY)
    {
        return new Vector2(frac.x * maxX, frac.y * maxY);
        /*transform.localPosition = new Vector3(frac.x * minimapTransform.rect.width,
                                            frac.y * minimapTransform.rect.height,
                                            transform.position.z);*/
    }
}
