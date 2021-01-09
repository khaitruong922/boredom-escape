using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    [SerializeField]
    private TaskView taskView;
    public void DisplayTask(Task task){
        taskView.gameObject.SetActive(true);
        taskView.DisplayTask(task);
    }
        public void HideTask(){
        taskView.gameObject.SetActive(false);
    }
}
