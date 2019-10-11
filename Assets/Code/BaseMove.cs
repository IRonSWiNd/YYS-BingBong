using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    //仅供测试用加速度脚本
    public GameObject ball;
    public Vector3 ball_v;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = ball_v;

    }

    void Update()
    {
        
    }
}
