using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public const string CurrentScoreKey = "CurrentScore";
    public const string HighScoreKey = "HighScore";
    public TMP_Text scoreText;
    void Update()
    {
        if (GameManager.Instance.canScoring)
        {
            {
                scoreText.text = "score: " + PlayerPrefs.GetInt(CurrentScoreKey).ToString() + "\nbestScore: " + PlayerPrefs.GetInt(HighScoreKey).ToString();
            }
        }
    }
    public void BtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
