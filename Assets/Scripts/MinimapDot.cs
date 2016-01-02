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

        image.color = Faction.ToRGB(ship.GetComponent<Ship>().GetColor());
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
        return UsefulMath.ToFracCoord(new Vector2(ship.transform.position.x, ship.transform.position.y),
                                        ScreenWrapBehavior.WRAP_SIZE, ScreenWrapBehavior.WRAP_SIZE);
    }


    private void SetRectTransformFromFrac(Vector2 frac)
    {
        Vector2 newCoord = UsefulMath.ToAbsCoord(frac, minimapTransform.rect.width, minimapTransform.rect.height);
        transform.localPosition = new Vector3(newCoord.x, newCoord.y, transform.position.z);
    }

}
