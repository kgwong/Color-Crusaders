using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactionEditorPanel : MonoBehaviour {

    public bool enableFaction;
    public Color color;
    public string optionalName;
    public int numUnits;

    public Toggle toggle;
    public Text hexInputText;

    private Image image;

	void Start ()
    {
        image = GetComponent<Image>();
        enableFaction = toggle.isOn;
        OnHexColorSubmit(hexInputText.text);
        numUnits = int.Parse(transform.Find("Units/Text").GetComponent<Text>().text);
        optionalName = transform.Find("OptionalName/Text").GetComponent<Text>().text;
        SetToggleBoxColor(color);
	}

    public void OnPanelColorChanged(Color color)
    {
        this.color = color;
        image.color = new Color(color.r, color.g, color.b, image.color.a);
        SetToggleBoxColor(color);
    }

    public void OnHexColorSubmit(string hex)
    {
        if (hex.Length == 7 && hex.StartsWith("#"))
        {
            try
            {
                int hexVal = System.Convert.ToInt32(hex.Substring(1, 6), 16);

                float R = (hexVal >> 16) & 255;
                float G = (hexVal >> 8) & 255;
                float B = hexVal & 255;

                color = new Vector4(R / 255, G / 255, B / 255, 1);
                OnPanelColorChanged(color);
            }
            catch (System.FormatException)
            {
                return;
            }
        }
        else return;
    }

    public void OnToggleChecked(bool value)
    {
        enableFaction = value;
    }

    public void OnUnitsEntered(string units)
    {
        numUnits = int.Parse(units);
    }

    private void SetToggleBoxColor(Color newColor)
    {
        toggle.transform.Find("Background").GetComponent<Image>().color = newColor;

    }

}
