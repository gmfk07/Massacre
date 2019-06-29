using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool displaying = false;
    private bool mouseOver = false;
    [SerializeField] private int furthestRight;
    [SerializeField] private Canvas canvas;

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

            var rt = gameObject.GetComponent<RectTransform>();
            var refRes = (canvas.transform as RectTransform).sizeDelta;

            if (rt.position.x > furthestRight)
                rt.position = new Vector2(furthestRight, rt.position.y);

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
