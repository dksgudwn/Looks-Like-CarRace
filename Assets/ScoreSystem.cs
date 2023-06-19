using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    public const string CurrentScoreKey = "CurrentScore";
    public const string HighScoreKey = "HighScore";
    private float score;

    void Update()
    {
        if (GameManager.Instance.canScoring)
            score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
    private void OnDestroy()
    {
        Debug.Log("Á×À½");
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        PlayerPrefs.SetInt(CurrentScoreKey, Mathf.FloorToInt(score));
        //PlayerPrefs.SetInt(HighScoreKey, 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
