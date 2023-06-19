using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    public const string CurrentScoreKey = "CurrentScore";
    public const string HighScoreKey = "HighScore2";
    private float score;

    void Update()
    {
        if (GameManager.Instance.canScoring)
        {
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = Mathf.FloorToInt(score).ToString();
            PlayerPrefs.SetInt(CurrentScoreKey, Mathf.FloorToInt(score));
            if (score > PlayerPrefs.GetInt(HighScoreKey, 0))
            {
                PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
            }
        }
        else if (!GameManager.Instance.canScoring)
        {
            Invoke("scored", 2f);
        }
    }
    void scored()
    {
        scoreText.text = "\n\n\nscore: " + PlayerPrefs.GetInt(CurrentScoreKey).ToString() + "\nbestScore: " + PlayerPrefs.GetInt(HighScoreKey).ToString();
    }
    private void OnDestroy()
    {
        Debug.Log("Á×À½");
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
