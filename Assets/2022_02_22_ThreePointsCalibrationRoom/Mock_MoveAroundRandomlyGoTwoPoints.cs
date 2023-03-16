using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mock_MoveAroundRandomlyGoTwoPoints : MonoBehaviour
{
    public Transform m_whatToMove;
    public Transform[] m_whereToGoPoints;

    public Transform m_previousPoint;
    public Transform m_nextPoint;

    public float m_movingTime=3;
    public float m_waitingTime=2;

    public float m_timeSequence;
    public int m_index;
    public float m_percentMoving;

    private void Awake()
    {

        DefineNext();
    }


    public void Update()
    {
        m_timeSequence += Time.deltaTime;
        if (m_timeSequence < m_movingTime)
        {
            m_percentMoving = m_timeSequence / m_movingTime;
            m_whatToMove.position = Vector3.Lerp(m_previousPoint.position, m_nextPoint.position, m_percentMoving);
            m_whatToMove.rotation = Quaternion.Lerp(m_previousPoint.rotation, m_nextPoint.rotation, m_percentMoving);
        }
        else if (m_timeSequence < m_movingTime + m_waitingTime)
        {

        }
        else
        {
            DefineNext();
        }

    }

    private void DefineNext()
    {
        m_index++;
        if (m_nextPoint == null)
            m_previousPoint = m_whereToGoPoints[0];
        else 
            m_previousPoint = m_nextPoint;
        m_nextPoint = m_whereToGoPoints[m_index % m_whereToGoPoints.Length];
        m_timeSequence = 0;
    }

    private void Reset()
    {
        m_whatToMove = this.transform;
    }
}
