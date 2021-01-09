using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TaskState
{
    Ready,
    InProgress,
    Finish,
    OnCooldown
}
public class TaskGiver : MonoBehaviour
{
    [SerializeField]
    private Task task;
    public Task Task => task;
    private TaskState taskState = TaskState.Ready;
    private float timeToFinish;
    private float cooldownLeft;
    private void Start()
    {
        ResetTask();
    }
    private void Update()
    {
        if (taskState == TaskState.InProgress)
        {
            TickDuration();
            return;
        }
        if (taskState == TaskState.OnCooldown)
        {
            TickCooldown();
            return;
        }
    }
    public bool HasAction => taskState == TaskState.Ready || taskState == TaskState.Finish;
    public void HandleAction()
    {
        if (taskState == TaskState.Ready)
        {
            taskState = TaskState.InProgress;
            return;
        }
        if (taskState == TaskState.Finish)
        {
            taskState = TaskState.OnCooldown;
            return;
        }
    }
    private void ResetTask()
    {
        taskState = TaskState.Ready;
        timeToFinish = task.duration;
        cooldownLeft = task.cooldown;
    }
    private void TickDuration()
    {
        timeToFinish -= Time.deltaTime;
        if (timeToFinish <= 0)
        {
            taskState = TaskState.Finish;
        }
    }
    private void TickCooldown()
    {
        cooldownLeft -= Time.deltaTime;
        if (cooldownLeft <= 0)
        {
            taskState = TaskState.Ready;
            ResetTask();
        }
    }
}
