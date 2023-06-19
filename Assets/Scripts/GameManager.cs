using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<Sprite> cars = new List<Sprite>();
    [SerializeField]
    List<GameObject> RealCars = new List<GameObject>();
    public int carIndex = 0;
    public bool carDestroy;
    public Transform SpawnPosition;
    int i = 1;

    [SerializeField]
    GameObject carImage;

    public GameObject SelectPanel;
    public GameObject RestartPanel;
    public GameObject ControlUI;
    public bool canScoring = false;
    public const string CurrentScoreKey = "CurrentScore";
    public const string HighScoreKey = "HighScore2";

    public static GameManager Instance;
    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        cars.AddRange(Resources.LoadAll<Sprite>("Image"));
        RealCars.AddRange(Resources.LoadAll<GameObject>("RealCar"));
        MonoBehaviour.DontDestroyOnLoad(this);
        SpawnPosition = GameObject.Find("SpawnPosition").transform;
        SelectPanel = GameObject.Find("SelectPanel");
        RestartPanel = GameObject.Find("RestartPanel");
        carImage = GameObject.Find("Image");
        RestartPanel.SetActive(false);
    }
    void Update()
    {
        //if (GameManager.Instance.canScoring)
        //{
        //    {
        //        scoreText.text = "score: " + PlayerPrefs.GetInt(CurrentScoreKey).ToString() + "\nbestScore: " + PlayerPrefs.GetInt(HighScoreKey).ToString();
        //    }
        //}
    }
    public void Left()
    {
        Debug.Log(carIndex);
        cars[carIndex] = cars[carIndex--];
        if (carIndex < 0)
        {
            carIndex = cars.Count - 1;
        }
        carImage.GetComponent<Image>().sprite = cars[carIndex];

    }
    public void Right()
    {
        Debug.Log(carIndex);
        cars[carIndex] = cars[carIndex++];
        if (carIndex > cars.Count - 1)
        {
            carIndex = 0;
        }
        carImage.GetComponent<Image>().sprite = cars[carIndex];
    }

    public void InGameStart()
    {
        canScoring = true;
        CarInstantiate();
        SelectPanel.SetActive(false);
    }
    public void CarInstantiate()
    {
        GameObject ob = Instantiate(RealCars[carIndex], SpawnPosition.transform);
        ControlUI = GameObject.Find("ControlCanvas");
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        RestartPanel.SetActive(true);
        ControlUI.SetActive(false);
    }
    public void ReStartBtnClick()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
