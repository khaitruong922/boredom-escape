using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskButton : MonoBehaviour
{
    [SerializeField]
    private TaskView taskView;
    [SerializeField]
    private GameObject taskButton;
    private TaskReceiver taskReceiver;
    private bool hasAction;
    private void Start()
    {
        taskReceiver = Player.Instance.GetComponent<TaskReceiver>();
    }
    private void Update()
    {
        if (hasAction == taskReceiver.HasAction()) return;
        hasAction = taskReceiver.HasAction();
        if (hasAction)
        {
            taskButton.SetActive(true);
            return;
        }
        taskButton.SetActive(false);
    }
    public void DisplayTask()
    {
        taskView.DisplayTask(taskReceiver.CurrentTaskGiver.Task);
    }
    public void HandleAction()
    {
        taskReceiver.HandleAction();
    }
}
