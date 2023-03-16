using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationZoneStateMono : MonoBehaviour
{

    public LockRotationZoneState m_rotatingState = new LockRotationZoneState();

    public void Start()
    {
        m_rotatingState.SetLockRotationWithCurrent();
    }
    public void SetCurrentRotation(Quaternion rotation)
    {
        m_rotatingState.SetCurrentRotation(rotation);
    }
    public void SetRotatingOutReferenceRotationWithCurrent()
    {
        m_rotatingState.SetLockRotationWithCurrent();
    }
}
