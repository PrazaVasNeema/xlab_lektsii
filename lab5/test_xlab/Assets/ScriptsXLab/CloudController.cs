using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField]
    private Cloud m_cloud;
    [SerializeField]
    private Transform[] m_points;
    private Transform m_current;
    private int m_currentIndex = 0;
    [SerializeField]
    private float m_speed = 5f;

    public void Action()
    {
//        m_cloud.StartRain();

        if (m_current == null)
        {
            m_cloud.StopRain();
            m_current = m_points[m_currentIndex];
            if (++m_currentIndex > m_points.Length)
            {
                m_currentIndex = 0;
            }
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (m_current != null)
        {
            var cloudPos = m_cloud.transform.position;
            var pos =  m_current.position; // position - позиция в сцене
            pos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * m_speed);
            if(Vector3.Distance(cloudPos, pos) < .1f)
            {
                m_current = null;
                OnMoveComplete();
            }

            m_cloud.transform.position = cloudPos;
        }
    }

    private void OnMoveComplete()
    {
        m_cloud.StartRain();
    }
}
