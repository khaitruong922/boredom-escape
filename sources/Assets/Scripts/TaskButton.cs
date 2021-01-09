using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskButton : MonoBehaviour
{
    [SerializeField]
    private TaskController taskController;
    private Image taskButtonImage;
    private TaskReceiver taskReceiver;
    private bool hasAction;
    private void Start()
    {
        taskButtonImage = GetComponent<Image>();
        taskReceiver = Player.Instance.GetComponent<TaskReceiver>();
    }
    private void Update()
    {
        if (hasAction == taskReceiver.HasAction()) return;
        hasAction = taskReceiver.HasAction();
        if (hasAction)
        {
            taskButtonImage.enabled = true;
            return;
        }
        taskButtonImage.enabled = false;
    }
    public void DisplayTask()
    {
        taskController.DisplayTask(taskReceiver.CurrentTaskGiver.Task);
    }
    public void HandleAction()
    {
        taskReceiver.HandleAction();
    }
}
