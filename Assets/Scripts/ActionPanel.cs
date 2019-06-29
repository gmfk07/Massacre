using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool displaying = false;
    private bool mouseOver = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (displaying && Input.GetMouseButtonUp(0))
        {
            Hide();
        }
    }

    //Hide the ActionPanel and destroy the buttons.
    private void Hide()
    {
        gameObject.SetActive(false);
        displaying = false;
        mouseOver = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    //Display the ActionPanel at the mouse position.
    public void Display()
    {
        if (!displaying)
        {
            gameObject.SetActive(true);
            transform.position = Input.mousePosition;
            displaying = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}
