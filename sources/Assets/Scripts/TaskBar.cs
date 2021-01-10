using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TaskBar : MonoBehaviour
{
    [SerializeField]
    private GameObject barContainer;
    [SerializeField]
    private Image taskBar;
    [SerializeField]
    private TextMeshProUGUI taskText;
    private void Start()
    {
        TaskGiver.OnTaskStart += ShowBar;
        TaskGiver.OnTaskEnd += HideBar;
        TaskGiver.OnTaskProgress += UpdateTaskBar;
    }
    private void UpdateTaskBar(float amount)
    {
        taskBar.fillAmount = amount;
    }
    private void HideBar()
    {
        barContainer.SetActive(false);
    }
    private void ShowBar(Task task)
    {
        taskText.text = task.title;
        barContainer.SetActive(true);
    }
    private void OnDestroy()
    {
        TaskGiver.OnTaskStart -= ShowBar;
        TaskGiver.OnTaskEnd -= HideBar;
        TaskGiver.OnTaskProgress -= UpdateTaskBar;
    }
}
