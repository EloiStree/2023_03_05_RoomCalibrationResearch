using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepyTwoCalibrationPointsMono : MonoBehaviour
{

   
    public TwoPointsCalibration m_calibrationPoints;
    public Transform m_origine;
    public Transform m_destination;

    public void SetWithDestinationFromOrigineWith(TwoPointsCalibration calibrationPoints) {
        m_calibrationPoints = calibrationPoints;
        Eloi.E_RelocationUtility.GetWorldToLocal_DirectionalPoint(calibrationPoints.m_positionEnd,calibrationPoints.m_rotationEnd, 
            calibrationPoints.m_positionStart, calibrationPoints.m_rotationStart,
            out Vector3 localPosition, out Quaternion localRotation);
        Eloi.E_RelocationUtility.GetLocalToWorld_DirectionalPoint(localPosition, localRotation,  m_origine.transform.position, m_origine.transform.rotation, out Vector3 worldPoint, out Quaternion worldRotation);
        m_destination.transform.position = worldPoint;
        m_destination.transform.rotation = worldRotation;
    }
}
