using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICoordinatesText : MonoBehaviour {

    public Camera cameraShip;
    public Text text;

    void Start () {
	}
	
	void Update ()
    {
        text.text = "X: " + cameraShip.transform.position.x.ToString("F2") + 
                    " Y: " + cameraShip.transform.position.y.ToString("F2");
	}
}
