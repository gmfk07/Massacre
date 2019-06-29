using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Teen : MonoBehaviour, IPointerClickHandler
{
    public string Name;
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxSanity;
    [SerializeField] private ActionPanel actionPanel;
    [SerializeField] private GameObject button;
    [SerializeField] private List<string> buttons;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        actionPanel.Display();
        for (int i = 0; i < buttons.Count; i++)
        {
            GameObject newButton = Instantiate(button, actionPanel.transform);
            newButton.GetComponentInChildren<Text>().text = buttons[i];
        }
    }
}
