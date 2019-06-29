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
    [SerializeField] private MessageManager messageManager;
    [SerializeField] private ActionPanel actionPanel;
    [SerializeField] private GameObject button;
    [SerializeField] private Text healthText;
    [SerializeField] private Text sanityText;
    [SerializeField] private List<TeenAction> availableActions;

    private int health;
    private int sanity;

    private void Start()
    {
        health = maxHealth;
        sanity = maxSanity;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        actionPanel.Display();
        for (int i = 0; i < availableActions.Count; i++)
        {
            GameObject newButton = Instantiate(button, actionPanel.transform);
            newButton.GetComponentInChildren<Text>().text = availableActions[i].message.Replace("<>", Name);
            newButton.GetComponent<Button>().onClick.AddListener(() => PerformTeenAction(availableActions[i]));
        }
    }

    private void PerformTeenAction(TeenAction action)
    {
        ChangeHealth(action.HealSanity);
        ChangeSanity(action.HealHealth);
    }

    private void ChangeHealth(int delta)
    {
        health = Mathf.Min(health + delta, maxHealth);
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }

    private void ChangeSanity(int delta)
    {
        sanity = Mathf.Min(sanity + delta, maxSanity);
        sanityText.text = sanity.ToString() + "/" + maxSanity.ToString();
    }
}
