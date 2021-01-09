using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGiver : MonoBehaviour
{
    [SerializeField]
    private Task task;
    public Task Task => task;
}
