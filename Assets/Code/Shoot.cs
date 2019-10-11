using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject m_ball;
    private Vector3 sPoint, ePoint;
    public static int y = 5;
    private float x, z = 0;
    public static Vector3 ball_v;
    public static bool isStart = false;
    public static bool isHit = false;
    void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        sPoint = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ePoint = Input.mousePosition;
        x = -(ePoint.x - sPoint.x)/10;
        z = -(ePoint.y - sPoint.y)/10;
        m_ball.AddComponent<Rigidbody>();
        ball_v.x = x;
        ball_v.y = y;
        ball_v.z = z;
        m_ball.GetComponent<Rigidbody>().velocity = ball_v;
        isStart = !isStart;
        GetComponent<Shoot>().enabled = false;
    }

}
