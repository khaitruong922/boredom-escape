using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DefeatView : MonoBehaviour
{
    [SerializeField]
    private GameObject defeatScreen;
    [SerializeField]
    private TextMeshProUGUI scoreText, highScoreText, timeText;
    private void Start()
    {
        GameManager.OnDefeat += OnDefeat;
    }

    private void OnDefeat()
    {
        defeatScreen.SetActive(true);
        Time.timeScale = 0f;
        Score score = Player.Instance.GetComponent<Score>();
        scoreText.text = score.MyScore.ToString();
        highScoreText.text = score.HighScore.ToString();
        timeText.text = TimerView.GetMinSecString();
    }
    private void OnDestroy() {
        GameManager.OnDefeat -= OnDefeat;
    }
}
