using UnityEngine;
using System.Collections;

public class ToggleCanvasGroupAlpha : MonoBehaviour {

    private CanvasGroup canvasGroup;

    public bool hidden;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        UpdateCanvasGroupAlpha();
    }

    void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
	}

    public void Toggle()
    {
        hidden = !hidden;
        UpdateCanvasGroupAlpha();
    }

    void UpdateCanvasGroupAlpha()
    {
        canvasGroup.alpha = hidden ? 0 : 1;
        canvasGroup.interactable = !hidden;
    }
}
