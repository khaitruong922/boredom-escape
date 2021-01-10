using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    private void Start()
    {
        Score score = Player.Instance.GetComponent<Score>();
        score.OnScoreChanged += UpdateScore;
        score.OnHighScoreChanged += UpdateHighScore;
        UpdateScore(score.MyScore);
        UpdateHighScore(score.HighScore);
    }

    private void UpdateHighScore(int score)
    {
        highScoreText.text = score.ToString();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
