using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TaskView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText, descriptionText, durationText, cooldownText, energyText, healthText;

    public void DisplayTask(Task task)
    {
        titleText.text = task.title;
        descriptionText.text = task.description;
        durationText.text = task.duration.ToString();
        cooldownText.text = task.cooldown.ToString();
        cooldownText.text = task.energy.ToString();
        energyText.text = task.health.ToString();

    }
}

