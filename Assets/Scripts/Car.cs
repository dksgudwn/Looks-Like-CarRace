using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    [SerializeField] GameObject scoreMaster;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject dieEffect;
    [SerializeField] GameObject dieCanvas;
    float timer = 0;

    private int steerValue;
    Rigidbody rb;

    private void Start()
    {
        dieCanvas.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(Vector3.down * 5f, ForceMode.Acceleration);
        _speed += _speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
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
        camera.GetComponent<CinemachineVirtualCamera>().m_Follow = null;
        Instantiate(dieEffect, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
        Handheld.Vibrate();
        Invoke("panel", 2);
    }

    private void panel()
    {
        scoreMaster.GetComponent<ScoreSystem>().canScoring = false;
        dieCanvas.SetActive(true);
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //SceneManager.LoadScene(0);
    }

    public void Steer(int value) //조종하다.
    {
        steerValue = value;
    }
}
