using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TaskView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText, descriptionText, durationText, energyText, healthText, scoreText;

    public void DisplayTask(Task task)
    {
        titleText.text = task.title;
        descriptionText.text = task.description;
        durationText.text = task.duration.ToString();
        healthText.text = task.health.ToString();
        energyText.text = task.energy.ToString(); 
        scoreText.text = task.score.ToString();
    }
}

