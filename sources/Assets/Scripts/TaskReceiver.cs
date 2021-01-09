using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskReceiver : MonoBehaviour
{
    private Task triggeredTask = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        TaskGiver taskGiver = other.GetComponent<TaskGiver>();
        if (taskGiver == null) return;
        triggeredTask = taskGiver.Task;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        TaskGiver taskGiver = other.GetComponent<TaskGiver>();
        if (taskGiver == null) return;
        triggeredTask = null;
    }
}
