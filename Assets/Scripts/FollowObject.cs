using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public GameObject obj;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        transform.position = new Vector3(obj.transform.position.x, 
                                        obj.transform.position.y, 
                                        obj.transform.position.z - 10);
    }
}
