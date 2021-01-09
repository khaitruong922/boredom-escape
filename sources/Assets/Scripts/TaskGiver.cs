using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TaskState
{
    Ready,
    InProgress,
    OnCooldown
}
public class TaskGiver : MonoBehaviour
{
    [SerializeField]
    private Task task;
    public Task Task => task;
    private TaskState taskState = TaskState.Ready;
    private TaskReceiver taskReceiver;
    private float timeToFinish;
    private float cooldownLeft;
    private void Start()
    {
        taskReceiver = Player.Instance.GetComponent<TaskReceiver>();
        ResetTask();
    }
    private void Update()
    {
        if (taskState == TaskState.InProgress)
        {
            if (taskReceiver.CurrentTaskGiver != this)
            {
                ResetTask();
                return;
            }
            TickDuration();
            return;
        }
        if (taskState == TaskState.OnCooldown)
        {
            TickCooldown();
            return;
        }
    }
    public bool HasAction => taskState == TaskState.Ready;
    public void HandleAction()
    {
        if (taskState == TaskState.Ready)
        {
            taskState = TaskState.InProgress;
            return;
        }
    }
    private void ResetTask()
    {
        print("Task reset");
        taskState = TaskState.Ready;
        timeToFinish = task.duration;
        cooldownLeft = task.cooldown;
    }
    private void TickDuration()
    {
        timeToFinish -= Time.deltaTime;
        if (timeToFinish <= 0)
        {
            // Give reward
            taskReceiver.ReceiveTaskRewards(task);
            taskState = TaskState.OnCooldown;
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
