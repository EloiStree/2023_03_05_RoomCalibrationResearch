using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAlmostStableMono : MonoBehaviour
{
    public IsAlmostNotMovingMono m_notMovingTracker;
    public IsAlmostNotRotatingMono m_notRotatingTracker;
    public float m_timeToBeConsiderStable = 0.1f;
    public bool m_isStable;
    public float m_stableTimer;

   
    void Update()
    {
        m_isStable = m_notMovingTracker.m_notMovingTimer >= m_timeToBeConsiderStable &&
             m_notRotatingTracker.m_notRotatingTimer >= m_timeToBeConsiderStable ;
        if (!m_isStable)
        {
            m_stableTimer = 0;
        }
        else
        {
            m_stableTimer += Time.deltaTime;
        }
    }
}
