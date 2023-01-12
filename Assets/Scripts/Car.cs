using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;
    float timer = 0;

    private int steerValue;
    void Update()
    {
        _speed += _speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
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
