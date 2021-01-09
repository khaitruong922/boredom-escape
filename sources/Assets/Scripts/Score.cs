using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Score : MonoBehaviour
{
    public Action<int> OnScoreChanged { get; set; }
    public Action<int> OnHighScoreChanged { get; set; }
    private int score = 0;
    private const string key = "Score";
    private void Start()
    {
        OnScoreChanged?.Invoke(0);
        OnHighScoreChanged?.Invoke(HighScore);
    }
    public void AddScore(int amount)
    {
        score += amount;
        SaveScore();
        OnScoreChanged?.Invoke(score);
    }
    public int HighScore => PlayerPrefs.GetInt(key, 0);
    public void SaveScore()
    {
        if (score > HighScore)
        {
            PlayerPrefs.SetInt(key, score);
            OnHighScoreChanged?.Invoke(score);
        }
    }
}
