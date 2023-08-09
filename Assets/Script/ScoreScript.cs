using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    int score = 0;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void scored()
    {
        score += 1;
        scoreText.text = PlayerPrefs.GetInt("Score",score).ToString();

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }
    //private void SaveScore()
    //{
    //    PlayerPrefs.SetInt("Score", score);
    //}
}
