using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    private Vector3 startPoint;
    public Camera m_camera;
    public GameObject dragfield;
    private int m_life;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        m_life = 5;
        Debug.LogError(string.Format("游戏开始，你有{0}次机会", m_life));
    }

    // Update is called once per frame
    void Update()
    {
        if (Shoot.isStart && GetComponent<Rigidbody>().velocity.y == 0)
        {
            Shoot.isStart = !Shoot.isStart;
            if (!Shoot.isHit)
            {
                m_life--;
                if (m_life > 0)
                {
                    Destroy(GetComponent<Rigidbody>());
                    transform.position = startPoint;
                    dragfield.GetComponent<Shoot>().enabled = true;
                    Debug.LogError(string.Format("没进，还有{0}次机会", m_life));
                }
                else
                {
                    Debug.LogError("游戏结束，请直接重开！");
                }
            }
            else
            {
                Destroy(GetComponent<Rigidbody>());
                startPoint += Vector3.one;
                transform.position = startPoint;
                m_camera.transform.position += Vector3.one;
                Shoot.isHit = !Shoot.isHit;
                Debug.LogError("下一关！");
            }            
        }
    }
    private void OnCollisionEnter(Collision cl)
    {
        if (cl.collider.name == "CupDown" && !Shoot.isHit)
        {
            Shoot.isHit = true;
            Debug.LogError("得分！");
        }
    }
}
