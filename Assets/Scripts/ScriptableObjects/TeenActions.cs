using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TeenAction", order = 1)]
public class TeenAction : ScriptableObject
{
    [Tooltip("The chat message that displays, the substring <> will be replaced with teen's name.")] public string message;
    public string Name;
    public int Damage;
    public int Insight;
    public int HealHealth;
    public int HealSanity;
}
