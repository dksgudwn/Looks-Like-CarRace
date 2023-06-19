using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    [SerializeField] private float _speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;


    [SerializeField] GameObject _camera;
    [SerializeField] GameObject dieEffect;
    float timer = 0;

    private float steerValue;
    Rigidbody rb;
    private bool isMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isMove = false;
    }
    private void Start()
    {
        _speed = 30;
    }
    void Update()
    {
        if (isMove)
        {
            rb.AddForce(Vector3.down * 1000000, ForceMode.Acceleration);
            _speed += _speedGainPerSecond * Time.deltaTime;
        }

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            End();
        }
    }

    private void End()
    {
        _camera.GetComponent<CinemachineVirtualCamera>().m_Follow = null;
        gameObject.GetComponent<AudioSource>().enabled = false;
        Instantiate(dieEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        Handheld.Vibrate();
        GameManager.Instance.canScoring = false;
        Invoke(nameof(CallGameOver), 2);
    }

    private void CallGameOver()
    {
        GameManager.Instance.GameOver();
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Steer(int value) //�����ϴ�.
    {
        steerValue = value;
    }

    public void StartBtnClick()
    {
        Debug.Log("Start");
        //StartBtn.SetActive(false);
        isMove = true;
    }
    
}
