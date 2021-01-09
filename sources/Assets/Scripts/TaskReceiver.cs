using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Energy), typeof(Score))]
public class TaskReceiver : MonoBehaviour
{
    private Health health;
    private Energy energy;
    private Score score;
    private void Awake()
    {
        health = GetComponent<Health>();
        energy = GetComponent<Energy>();
        score = GetComponent<Score>();
    }
    private TaskGiver currentTaskGiver = null;
    public TaskGiver CurrentTaskGiver => currentTaskGiver;
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
    private void Start()
    {
        TaskGiver.OnTaskFinished += ReceiveTaskRewards;
    }
    public void HandleAction()
    {
        currentTaskGiver.HandleAction();
    }
    public void ReceiveTaskRewards(Task task)
    {
        health.ModifyHP(task.health);
        energy.ModifyEnergy(task.energy);
        score.AddScore(task.score);
    }
}
