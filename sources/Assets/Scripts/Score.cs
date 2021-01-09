using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Score : MonoBehaviour
{
    public Action OnScoreChanged { get; set; }
    public Action OnHighScoreChanged { get; set; }
    private int score = 0;
    private const string key = "Score";
    private void Start()
    {
        GameManager.OnDefeat += SaveScore;
    }
    public void AddScore(int amount)
    {
        score += amount;
        // SaveScore();
        OnScoreChanged?.Invoke();
    }
    private int HighScore => PlayerPrefs.GetInt(key, 0);
    public void SaveScore()
    {
        if (score > HighScore)
        {
            PlayerPrefs.SetInt(key, score);
            OnHighScoreChanged?.Invoke();
        }
    }
}
