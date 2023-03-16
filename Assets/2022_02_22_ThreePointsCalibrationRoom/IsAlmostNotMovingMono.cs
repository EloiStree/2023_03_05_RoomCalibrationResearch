using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class IsAlmostNotMovingMono : MonoBehaviour
{
    public LockPositionZoneStateMono m_lockState;
    public UnityEvent m_targetMoved;
    public float m_notMovingTimer;

    public void Update()
    {
        if (m_lockState.m_movingState.IsOutOfMovingLock())
        {
            m_notMovingTimer = 0;
            m_lockState.SetMovingOutReferencePositionWithCurrent();
            m_targetMoved.Invoke();
        }
        else
        {
            m_notMovingTimer += Time.deltaTime;
        }
    }
}
[System.Serializable]
public class LockPositionZoneState {

    public Vector3 m_currentPosition;
    public Vector3 m_lockPosition;
    public float m_moveRangeRadius = 0.03f;
    public bool m_isMovingOutState;

    public bool IsOutOfMovingLock() {
        E_NotMovingDetection.IsTwoPointConsiderAsMoved(m_currentPosition, m_lockPosition, m_moveRangeRadius, out bool isMovingSinceLastTime);
        return isMovingSinceLastTime;
    }

    public void SetCurrentPosition(Vector3 position)
    {
        m_currentPosition = position;
        UpdateInState();
    }

    private void UpdateInState()
    {
        m_isMovingOutState = IsOutOfMovingLock();
    }

    public void SetLockPositionWithCurrent()
    {
        SetLockPosition(m_currentPosition);
    }
    public void SetLockPosition(Vector3 position)
    {
        m_lockPosition = position;
    }
    public void SetRangeDistance(float range)
    {
        m_moveRangeRadius = range;
        UpdateInState();
    }
}

