using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public GameObject obj;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(obj.transform.position.x, 
                                        obj.transform.position.y, 
                                        obj.transform.position.z - 10);
    }
}
