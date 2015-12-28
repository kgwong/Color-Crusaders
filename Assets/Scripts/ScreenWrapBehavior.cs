using UnityEngine;
using System.Collections;

public class ScreenWrapBehavior : MonoBehaviour {

    public const float WRAP_SIZE = 100.0f;

    /*Since screen wrapping involves teleporting the object,
    a TrailRenderer on the object will also teleporting,
    creating an ugly line across the teleportation points. 
    This script requires a reference to the TrailRenderer to 
    work around this. */

    public TrailRenderer trailRenderer;
    private float trailTime;

    void Start ()
    {
        //tr = GetComponent<TrailRenderer>();
	}
	
	void Update ()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        bool teleportX = true;
        bool teleportY = true;

        if (posX < -WRAP_SIZE / 2)
            posX += WRAP_SIZE;
        else if (posX > WRAP_SIZE / 2)
            posX -= WRAP_SIZE;
        else
            teleportX = false;

        if (posY < -WRAP_SIZE / 2)
            posY += WRAP_SIZE;
        else if (posY > WRAP_SIZE / 2)
            posY -= WRAP_SIZE;
        else
            teleportY = false;

        if (teleportX || teleportY)
        {
            transform.position = new Vector3(posX, posY, transform.position.z);
            StartCoroutine("ResetTrailRenderer");
        }
    }


    //http://answers.unity3d.com/questions/795853/teleporting-trail-renderer.html
    IEnumerator ResetTrailRenderer()
    {
        if (trailRenderer)
        {
            trailTime = trailRenderer.time;
            trailRenderer.time = 0;
            yield return null;
            trailRenderer.time = trailTime;
        }
    }
}
