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
        UpdateHealthText();
        UpdateSanityText();
    }

    private void UpdateSanityText()
    {
        sanityText.text = sanity.ToString() + "/" + maxSanity.ToString();
    }

    private void UpdateHealthText()
    {
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        actionPanel.Display();
        for (int i = 0; i < availableActions.Count; i++)
        {
            GameObject newButton = Instantiate(button, actionPanel.transform);
            newButton.GetComponentInChildren<Text>().text = availableActions[i].Name;
            var x = i;
            newButton.GetComponent<Button>().onClick.AddListener(() => PerformTeenAction(x));
        }
    }

    private void PerformTeenAction(int actionIndex)
    {
        TeenAction action = availableActions[actionIndex];
        messageManager.PostMessage(action.message.Replace("<>", Name));
        ChangeHealth(action.HealHealth);
        ChangeSanity(action.HealSanity);
    }

    private void ChangeHealth(int delta)
    {
        health = Mathf.Clamp(health + delta, 0, maxHealth);
        UpdateHealthText();
    }

    private void ChangeSanity(int delta)
    {
        sanity = Mathf.Clamp(sanity + delta, 0, maxSanity);
        UpdateSanityText();
    }
}
