using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    //[SerializeField] private TMP_Text energyText;
    //[SerializeField] private int maxEnergy;
    //[SerializeField] private int energyRechargeDuration;
    //[SerializeField] private AndroidNotificationHandler androidNotificationHandler;

    //private int energy;

    //private const string EnergyKey = "Energy";
    //private const string EnergyReadyKey = "EnergyReady";
    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"High Score {highScore}";

        //energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        /*if(energy == 0)
        {
            string EnergyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (EnergyReadyKey == string.Empty) { return; }
            DateTime energyReady = DateTime.Parse(EnergyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        energyText.text = $"Play({energy})";*/
    }
    public void play()
    {
        /*if (energy < 1) { return; }
        energy--;

        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#endif
        }*/
        

        SceneManager.LoadScene(1);
    }
}
