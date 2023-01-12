using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    Rigidbody rigid;
    protected Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    float time;
    void Update()
    {
        Move();
        time += Time.deltaTime;
        if (time >= 1)
        {
            direction.Set(0f, Random.Range(0f, 360f), 0f);
            time = 0;
        }
        Rotation();
    }
    protected void Move()
    {
        rigid.MovePosition(transform.position + (transform.forward * 2 * Time.deltaTime));
    }
    protected void Rotation()
    {
        Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), 0.02f);
        rigid.MoveRotation(Quaternion.Euler(_rotation));
    }
}
