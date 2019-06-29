using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TeenAction", order = 1)]
public class TeenActions : ScriptableObject
{
    [Tooltip("The chat message that displays, the substring <> will be replaced with teen's name.")]public string message;
    public int damage;
    public int insight;
    public int healHealth;
    public int healSanity;
}
