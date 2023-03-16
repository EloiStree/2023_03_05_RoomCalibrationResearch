using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePointsToCalibrationIdMono : MonoBehaviour
{
    public ThreePointsCalibration m_givenCalibrationPoint;
    public void SetThreePoints(ThreePointsCalibration calibrationPoints)
    {


        m_fullLenghtAngleId.m_totalLenght = calibrationPoints.GetBordersLenght();
        m_fullLenghtAngleId.m_startToMiddleLenght = calibrationPoints.GetStartMiddleDistance();
        m_fullLenghtAngleId.m_endToMiddleLenght = calibrationPoints.GetMiddleEndDistance();
        m_fullLenghtAngleId.m_endToStartLenght = calibrationPoints.GetStartEndDistance();
        m_fullLenghtAngleId.m_startAngle = calibrationPoints.GetStartAngle();
        m_fullLenghtAngleId.m_middleAngle = calibrationPoints.GetMiddleAngle();
        m_fullLenghtAngleId.m_endAngle = calibrationPoints.GetEndAngle();

        m_axisLenghtId.m_startToMiddleLenght = calibrationPoints.GetStartMiddleDistance();
        m_axisLenghtId.m_endToMiddleLenght = calibrationPoints.GetMiddleEndDistance();
        m_axisLenghtId.m_totalLenght = calibrationPoints.GetBordersLenght();


        m_cartesianId.m_forwardAxeLenght = calibrationPoints.GetStartMiddleDistance();
        m_cartesianId.m_freeAxeLenght = calibrationPoints.GetMiddleEndDistance();
        m_cartesianId.m_axisAngle = calibrationPoints.GetMiddleAngle();
    }

    public ThreePointsLenghtAndAngleAnchor m_fullLenghtAngleId;
    public ThreePointsAxisLenghtAnchor m_axisLenghtId;
    public ThreePointsCartesianAnchor m_cartesianId;
}
