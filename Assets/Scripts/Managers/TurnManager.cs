using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [HideInInspector] public List<Teen> teens = new List<Teen>();
    [SerializeField] private int teenActionsPerTurn;
    private int teenActionsPerformed;

    public void IncreaseTeenActions()
    {
        teenActionsPerformed++;
        if (teenActionsPerformed == teenActionsPerTurn)
        {
            StartTeenTurn();
        }
    }

    private void StartTeenTurn()
    {
        teenActionsPerformed = 0;
        foreach (Teen teen in teens)
        {
            teen.HandleNewTurn();
        }
    }

    private void StartKillerTurn()
    {

    }
}
