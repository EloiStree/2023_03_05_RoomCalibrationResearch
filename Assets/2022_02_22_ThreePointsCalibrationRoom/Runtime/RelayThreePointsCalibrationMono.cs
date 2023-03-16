using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RelayThreePointsCalibrationMono : MonoBehaviour
{
    public ThreePointsCalibration m_lastReceived;
    public ThreePointsCalibrationEvent m_relayed;

    [ContextMenu("Repush")]
    public void Repush()
    {
        Push(m_lastReceived);
    }

    public void Push(ThreePointsCalibration calibrationPoints)
    {
        m_lastReceived = calibrationPoints;
        m_relayed.Invoke(calibrationPoints);
    }
}