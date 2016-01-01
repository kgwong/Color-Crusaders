using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Minimap : MonoBehaviour {

    public GameObject dot;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void AddDot(GameObject ship)
    {
        GameObject newDot = (GameObject) Instantiate(dot, new Vector3(), Quaternion.identity);
        newDot.transform.parent = this.transform;
        MinimapDot script = newDot.GetComponent<MinimapDot>();
        script.ship = ship;
    }
}
