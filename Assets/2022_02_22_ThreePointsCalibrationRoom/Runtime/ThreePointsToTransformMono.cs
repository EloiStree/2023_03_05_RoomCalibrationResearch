using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePointsToTransformMono : MonoBehaviour
{
    public Transform m_rootPoints;
    public Transform m_middlePoint;
    public Transform m_startPoint;
    public Transform m_endPoint;
    public void SetThreePoints(ThreePointsCalibration calibrationPoints)
    {
        calibrationPoints.GetMiddleAsOrigineCross(out Vector3 start, out Vector3 aDirection, out Vector3 bDirection);
        calibrationPoints.GetMiddleAsOrigineCartesian(out  start, out Vector3 right, out Vector3 up, out Vector3 forward, out Quaternion orientation);

        
        m_rootPoints.position = start;
        m_rootPoints.rotation = orientation;



        m_middlePoint.position = calibrationPoints.m_pointMiddle.m_position;
        m_startPoint.position = calibrationPoints.m_pointStart.m_position;
        m_endPoint.position = calibrationPoints.m_pointEnd.m_position;

        m_middlePoint.rotation = calibrationPoints.m_pointMiddle.m_rotation;
        m_startPoint.rotation = calibrationPoints.m_pointStart.m_rotation;
        m_endPoint.rotation = calibrationPoints.m_pointEnd.m_rotation;


    }

}
