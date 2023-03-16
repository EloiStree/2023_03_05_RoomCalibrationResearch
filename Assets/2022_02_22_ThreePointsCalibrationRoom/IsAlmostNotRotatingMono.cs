using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsAlmostNotRotatingMono : MonoBehaviour
{
    public LockRotationZoneStateMono m_lockState;
    public UnityEvent m_targetRotated;
    public float m_notRotatingTimer;

    public void Update()
    {
        if (m_lockState.m_rotatingState.IsOutOfRotationLock())
        {
            m_notRotatingTimer = 0;
            m_lockState.SetRotatingOutReferenceRotationWithCurrent();
            m_targetRotated.Invoke();
        }
        else {
            m_notRotatingTimer += Time.deltaTime;
        }
    }

}
[System.Serializable]
public class LockRotationZoneState
{

    public Quaternion m_currentRotation;
    public Quaternion m_lockRotation;
    public float m_rotationRangeAngle = 3;
    public bool m_isRotatingOutState;

    public bool IsOutOfRotationLock()
    {
        E_NotMovingDetection.IsTwoPointConsiderAsRotated(m_currentRotation, m_lockRotation, m_rotationRangeAngle, out bool isMovingSinceLastTime);
        return isMovingSinceLastTime;
    }

    public void SetCurrentRotation(Quaternion position)
    {
        m_currentRotation = position;
        UpdateInState();
    }

    private void UpdateInState()
    {
        m_isRotatingOutState = IsOutOfRotationLock();
    }

    public void SetLockRotationWithCurrent()
    {
        SetLockRotation(m_currentRotation);
    }
    public void SetLockRotation(Quaternion position)
    {
        m_lockRotation = position;
        UpdateInState();
    }
    public void SetRangeAngle(float angle) {
        m_rotationRangeAngle = angle;
    }
}

