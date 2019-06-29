using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [HideInInspector] public List<Teen> Teens = new List<Teen>();
    [HideInInspector] public Killer Killer;
    [HideInInspector] public Dictionary<Teen, TeenAction> teenActionDict = new Dictionary<Teen, TeenAction>();

    [SerializeField] private int teenActionsPerTurn;

    private int teenActionsPerformed;

    public void IncreaseTeenActions()
    {
        teenActionsPerformed++;
        if (teenActionsPerformed == teenActionsPerTurn)
        {
           StartCoroutine(Killer.HandleKillerTurn());
        }
    }

    public void StartTeenTurn()
    {
        teenActionsPerformed = 0;
        teenActionDict.Clear();
        foreach (Teen teen in Teens)
        {
            teen.HandleNewTurn();
        }
    }
}
