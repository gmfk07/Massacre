using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/KillerAction", order = 1)]
public class KillerAction : ScriptableObject
{
    public string message;
    public int damage;
    public int insanity;
    public Target target;
}
