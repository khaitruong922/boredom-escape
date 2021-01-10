using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TaskView : MonoBehaviour
{
    [SerializeField]
    private Color positiveColor, neutralColor, negativeColor;
    [SerializeField]
    private TextMeshProUGUI titleText, descriptionText, durationText, energyText, healthText, scoreText;

    public void DisplayTask(Task task)
    {
        titleText.text = task.title;
        descriptionText.text = task.description;

        durationText.text = task.duration.ToString();
        durationText.color = neutralColor;

        healthText.text = GetStatString(task.health);
        healthText.color = GetDisplayColor(task.health);

        energyText.text = GetStatString(task.energy);
        energyText.color = GetDisplayColor(task.energy);

        scoreText.text = GetStatString(task.score);
        scoreText.color = GetDisplayColor(task.score);
    }
    private string GetStatString(float value)
    {
        return (value >= 0 ? "+" : "") + value.ToString();
    }
    private Color GetDisplayColor(float value)
    {
        if (value > 0) return positiveColor;
        if (value == 0) return neutralColor;
        return negativeColor;
    }
}

