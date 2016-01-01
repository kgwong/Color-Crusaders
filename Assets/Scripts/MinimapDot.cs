using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinimapDot : MonoBehaviour {

    public GameObject ship;

    private RectTransform minimapTransform;
    private RectTransform rectTransform;
    private Image image;

    void Start ()
    {
        minimapTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        image.color = Ship.COLOR_DEFINITIONS[(int)ship.GetComponent<Ship>().GetColor()];
	}
	
	void Update ()
    {
	    if (ship != null)
        {
            UpdateRectTransform();
        }
        else
        {
            Destroy(gameObject);
        }
	}

    private void UpdateRectTransform()
    {
        Vector2 frac = CalcFracShipCoord();
        SetRectTransformFromFrac(frac);
    }

    private Vector2 CalcFracShipCoord()
    {
        Vector2 test = new Vector2(ship.transform.position.x / ScreenWrapBehavior.WRAP_SIZE, 
                            ship.transform.position.y / ScreenWrapBehavior.WRAP_SIZE);

        return test;
    }


    private void SetRectTransformFromFrac(Vector2 frac)
    {
        transform.localPosition = new Vector3(frac.x * minimapTransform.rect.width,
                                            frac.y * minimapTransform.rect.height,
                                            transform.position.z);
    }

}
