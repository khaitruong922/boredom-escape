using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum TaskState
{
    Ready,
    InProgress,
    OnCooldown
}
[RequireComponent(typeof(AudioSource))]
public class TaskGiver : MonoBehaviour
{
    public static Action<Task> OnTaskStart { get; set; }
    public static Action<float> OnTaskProgress { get; set; }
    public Action<float> OnTaskCooldown { get; set; }
    public static Action OnTaskEnd { get; set; }
    public static Action<Task> OnTaskFinished { get; set; }
    private AudioSource audioSource;
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
        audioSource = GetComponent<AudioSource>();
        ResetTask();
    }
    private void Update()
    {
        if (taskState == TaskState.InProgress)
        {
            if (taskReceiver.CurrentTaskGiver != this)
            {
                ResetTask();
                OnTaskEnd?.Invoke();
                return;
            }
            TickDuration();
            OnTaskProgress?.Invoke(1 - timeToFinish / task.duration);
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
            OnTaskStart?.Invoke(task);
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
            OnTaskFinished?.Invoke(task);
            OnTaskEnd?.Invoke();
            audioSource.Play();
            taskState = TaskState.OnCooldown;
        }
    }
    private void TickCooldown()
    {
        cooldownLeft -= Time.deltaTime;
        OnTaskCooldown?.Invoke(cooldownLeft / task.cooldown);
        if (cooldownLeft <= 0)
        {
            taskState = TaskState.Ready;
            ResetTask();
        }
    }
}
