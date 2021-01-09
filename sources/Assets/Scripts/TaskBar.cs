using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskBar : MonoBehaviour
{
    [SerializeField]
    private GameObject barContainer;
    [SerializeField]
    private Image taskBar;
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
    private void ShowBar()
    {
        barContainer.SetActive(true);
    }
}
