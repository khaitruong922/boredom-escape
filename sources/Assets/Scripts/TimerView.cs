using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    private float timeElapsed = 0f;
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        timerText.text = GetMinSecString();
    }
    private string GetMinSecString()
    {
        int minutes = (int)(timeElapsed / 60);
        int seconds = (int)(timeElapsed % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
