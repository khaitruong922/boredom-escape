using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskReceiver : MonoBehaviour
{
    private TaskGiver currentTaskGiver = null;
    public bool HasAction()
    {
        if (currentTaskGiver == null) return false;
        return currentTaskGiver.HasAction;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        TaskGiver taskGiver = other.GetComponent<TaskGiver>();
        if (taskGiver == null) return;
        currentTaskGiver = taskGiver;
        print(currentTaskGiver);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        TaskGiver taskGiver = other.GetComponent<TaskGiver>();
        if (taskGiver == null) return;
        currentTaskGiver = null;
        print(currentTaskGiver);
    }
    public void HandleAction()
    {
        currentTaskGiver.HandleAction();
    }
}
