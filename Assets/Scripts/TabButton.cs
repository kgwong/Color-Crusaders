using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class TabButton : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler
{
    public Text text;

    private Color originalColor;

    void Start()
    {
        originalColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = originalColor; 
    }
}

