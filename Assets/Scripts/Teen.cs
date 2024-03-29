﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Teen : MonoBehaviour, IPointerClickHandler
{
    public string Name;

    [SerializeField] private int maxHealth;
    [SerializeField] private int maxSanity;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private MessageManager messageManager;
    [SerializeField] private ActionPanel actionPanel;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject darknessOverlay;
    [SerializeField] private Text healthText;
    [SerializeField] private Text sanityText;
    [SerializeField] private List<TeenAction> availableActions;

    private bool acted = false;

    public int health { get; private set; }
    public int sanity { get; private set; }

    private void Start()
    {
        health = maxHealth;
        sanity = maxSanity;
        turnManager.Teens.Add(this);
        HandleNewTurn();
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
        if (!acted)
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
    }

    public void HandleNewTurn()
    {
        acted = false;
        darknessOverlay.SetActive(false);
    }

    private void PerformTeenAction(int actionIndex)
    {
        acted = true;
        darknessOverlay.SetActive(true);

        TeenAction action = availableActions[actionIndex];

        messageManager.PostMessage(action.message.Replace("<>", Name), true);
        ChangeHealth(action.HealHealth);
        ChangeSanity(action.HealSanity);
        turnManager.Killer.ChangeHealth(-action.Damage);
        turnManager.Killer.ChangeInsight(action.Insight);

        turnManager.IncreaseTeenActions();
    }

    public void ChangeHealth(int delta)
    {
        health = Mathf.Clamp(health + delta, 0, maxHealth);
        UpdateHealthText();
    }

    public void ChangeSanity(int delta)
    {
        sanity = Mathf.Clamp(sanity + delta, 0, maxSanity);
        UpdateSanityText();
    }
}
