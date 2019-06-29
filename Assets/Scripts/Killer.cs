using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killer : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private MessageManager messageManager;
    [SerializeField] private List<KillerAction> killerActions = new List<KillerAction>();
    [SerializeField] private float waitBetweenActions;
    [SerializeField] private float totalActions;
    [SerializeField] private Text healthText;
    [SerializeField] private Text insightText;
    private int health;
    private int insight = 0;

    private void Start()
    {
        health = startingHealth;
        turnManager.Killer = this;
        UpdateText();
    }

    public IEnumerator HandleKillerTurn()
    {
        for (int i = 0; i < totalActions; i++)
        {
            yield return new WaitForSeconds(waitBetweenActions);
            PerformKillerAction();
        }
        yield return new WaitForSeconds(waitBetweenActions);
        turnManager.StartTeenTurn();
    }

    public void ChangeHealth(int delta)
    {
        health += delta;
        UpdateText();
    }

    private void UpdateText()
    {
        healthText.text = health.ToString();
        insightText.text = insight.ToString();
    }

    public void ChangeInsight(int delta)
    {
        insight += delta;
        UpdateText();
    }

    public void PerformKillerAction()
    {
        int randInt = Random.Range(0, killerActions.Count);
        KillerAction selectedAction = killerActions[randInt];

        messageManager.PostMessage(selectedAction.message, false);
        List<Teen> targetList = new List<Teen>();

        switch (selectedAction.target)
        {
            case Target.LeastHealthTarget:
                targetList.Add(GetLeastHealthTarget());
                break;

            case Target.MostHealthTarget:
                targetList.Add(GetMostHealthTarget());
                break;

            case Target.LeastSanityTarget:
                targetList.Add(GetLeastSanityTarget());
                break;

            case Target.MostSanityTarget:
                targetList.Add(GetMostSanityTarget());
                break;

            case Target.RandomTarget:
                int index = Random.Range(0, turnManager.Teens.Count);
                targetList.Add(turnManager.Teens[index]);
                break;

            case Target.All:
                targetList = turnManager.Teens;
                break;
        }

        foreach (Teen teen in targetList)
        {
            teen.ChangeHealth(-selectedAction.damage);
            teen.ChangeSanity(-selectedAction.insanity);
        }
    }
    
    private Teen GetLeastHealthTarget()
    {
        int healthRecord = int.MaxValue;

        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.health > 0 && teen.health < healthRecord)
            {
                healthRecord = teen.health;
            }
        }

        List<Teen> possibleTargets = new List<Teen>();
        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.health == healthRecord)
            {
                possibleTargets.Add(teen);
            }
        }

        int index = Random.Range(0, possibleTargets.Count);
        return possibleTargets[index];
    }

    private Teen GetMostHealthTarget()
    {
        int healthRecord = 0;

        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.health > 0 && teen.health > healthRecord)
            {
                healthRecord = teen.health;
            }
        }

        List<Teen> possibleTargets = new List<Teen>();
        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.health == healthRecord)
            {
                possibleTargets.Add(teen);
            }
        }

        int index = Random.Range(0, possibleTargets.Count);
        return possibleTargets[index];
    }

    private Teen GetLeastSanityTarget()
    {
        int sanityRecord = int.MaxValue;

        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.sanity > 0 && teen.sanity < sanityRecord)
            {
                sanityRecord = teen.sanity;
            }
        }

        List<Teen> possibleTargets = new List<Teen>();
        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.health == sanityRecord)
            {
                possibleTargets.Add(teen);
            }
        }

        int index = Random.Range(0, possibleTargets.Count);
        return possibleTargets[index];
    }

    private Teen GetMostSanityTarget()
    {
        int SanityRecord = 0;

        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.sanity > 0 && teen.sanity > SanityRecord)
            {
                SanityRecord = teen.sanity;
            }
        }

        List<Teen> possibleTargets = new List<Teen>();
        foreach (Teen teen in turnManager.Teens)
        {
            if (teen.sanity == SanityRecord)
            {
                possibleTargets.Add(teen);
            }
        }

        int index = Random.Range(0, possibleTargets.Count);
        return possibleTargets[index];
    }
}
