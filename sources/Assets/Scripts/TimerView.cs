using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    private void Update()
    {
        timerText.text = GetMinSecString();
    }
    private string GetMinSecString()
    {
        float time = Time.time;
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
