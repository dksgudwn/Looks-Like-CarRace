using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    [SerializeField] GameObject scoreMaster;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject dieEffect;
    [SerializeField] GameObject StartBtn;
    [SerializeField] GameObject ReStartBtn;
    float timer = 0;

    private float steerValue;
    Rigidbody rb;
    private bool isMove;

    private void Awake()
    {
        ReStartBtn.SetActive(false);
        rb = GetComponent<Rigidbody>();
        isMove = false;
    }
    private void Start()
    {
        _speed = 0f;
    }
    void Update()
    {
        if (isMove)
        {
            rb.AddForce(Vector3.down * 10, ForceMode.Acceleration);
            _speed += _speedGainPerSecond * Time.deltaTime;
        }

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
            End();
        }
    }

    private void End()
    {
        GetComponent<Camera>().GetComponent<CinemachineVirtualCamera>().m_Follow = null;
        gameObject.GetComponent<AudioSource>().enabled = false;
        Instantiate(dieEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        Handheld.Vibrate();
        Invoke("GameOver", 2);
    }

    private void GameOver()
    {
        scoreMaster.GetComponent<ScoreSystem>().canScoring = false;
        ReStartBtn.SetActive(true);
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //SceneManager.LoadScene(0);
    }

    public void Steer(int value) //�����ϴ�.
    {
        steerValue = value;
    }

    public void StartBtnClick()
    {
        StartBtn.SetActive(false);
        _speed = 30f;
        isMove = true;
    }
}
