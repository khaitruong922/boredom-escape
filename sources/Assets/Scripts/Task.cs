using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task")]
public class Task : ScriptableObject
{
    public string title;
    [TextArea(3,5)]
    public string description;
    public float cooldown;
    public float duration;
    public float energy;
    public float health;
    public float point;
}
