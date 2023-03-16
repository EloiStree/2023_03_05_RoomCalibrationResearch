using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPositionZoneStateMono : MonoBehaviour
{
    public bool m_isMovingOutState;

    public LockPositionZoneState m_movingState = new LockPositionZoneState();

    public void Start()
    {
        m_movingState.SetLockPositionWithCurrent();
    }
    public void Update()
    {
        m_isMovingOutState = m_movingState.IsOutOfMovingLock();
    }
    public void SetCurrentPosition(Vector3 position)
    {
        m_movingState.SetCurrentPosition(position);
    }
    public void SetMovingOutReferencePositionWithCurrent()
    {
        m_movingState.SetLockPositionWithCurrent();
    }
}
