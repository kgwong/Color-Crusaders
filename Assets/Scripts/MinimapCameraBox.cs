using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinimapCameraBox : MonoBehaviour {

    private RectTransform minimapTransform;
    private RectTransform rectTransform;

    private Camera cam;
    
    void Start ()
    {
        minimapTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
        cam = Camera.main.GetComponent<Camera>();
        
        float cameraHeight = cam.orthographicSize * 2;
        float cameraWidth = cameraHeight * Screen.width / Screen.height;

        rectTransform.sizeDelta = new Vector2(cameraWidth / ScreenWrapBehavior.WRAP_SIZE * minimapTransform.rect.width,
                                                cameraHeight / ScreenWrapBehavior.WRAP_SIZE * minimapTransform.rect.height);


	}
	
	void Update ()
    {
        Vector2 frac = UsefulMath.ToFracCoord(new Vector2(cam.transform.position.x, cam.transform.position.y), 
                                                ScreenWrapBehavior.WRAP_SIZE, ScreenWrapBehavior.WRAP_SIZE);
        Vector2 abs = UsefulMath.ToAbsCoord(frac, minimapTransform.rect.width, minimapTransform.rect.height);

        transform.localPosition = new Vector3(abs.x, abs.y, 0);
	}
}
