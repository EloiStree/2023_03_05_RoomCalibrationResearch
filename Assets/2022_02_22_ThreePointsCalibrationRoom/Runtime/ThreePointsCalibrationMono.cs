using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThreePointsCalibrationMono : MonoBehaviour
{
    public ThreePointsCalibration m_calibrationPoints;
    public float m_borderLength;
    public bool m_useDraw;

    public void SetThreePoints(ThreePointsCalibration calibrationPoints) {
        m_calibrationPoints = calibrationPoints;
        m_borderLength = calibrationPoints.GetBordersLenght();
    }

    public void Update()
    {
        if (m_useDraw)
        {
            Vector3 up = Vector3.up * 0.01f;
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.yellow * 0.8f, m_calibrationPoints.m_pointMiddle.m_position + up * 2, m_calibrationPoints.m_pointStart.m_position + up * 2);
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.yellow * 0.2f, m_calibrationPoints.m_pointMiddle.m_position + up * 2, m_calibrationPoints.m_pointEnd.m_position + up * 2);
            m_calibrationPoints.GetMiddleAsOrigineCross( out Vector3 start, out Vector3 directionA, out Vector3 directionB);
            m_calibrationPoints.GetMiddleAsOrigineCartesian( out Vector3 startPosition, out Vector3 rightDirection, out Vector3 upDirection, out Vector3 forwardDirection);
           
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.magenta * 0.5f, start+ up, start + up + directionB * 0.8f);
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.magenta * 0.5f, start + up, start + up + directionA * 0.8f);
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.blue * 0.5f, start, start + forwardDirection * 0.5f);
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.red * 0.5f, start, start + rightDirection * 0.5f);
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.green*0.5f, start, start + upDirection * 0.5f);

        }
    }
}






[System.Serializable]
public class KeyPointCalibration
{
    public Vector3 m_position= new Vector3();
    public Quaternion m_rotation= Quaternion.identity;
}


    [System.Serializable]
public class ThreePointsCalibration {


    public KeyPointCalibration m_pointStart = new KeyPointCalibration();
    public KeyPointCalibration m_pointMiddle = new KeyPointCalibration();
    public KeyPointCalibration m_pointEnd = new KeyPointCalibration();

    public void GetThreePoints(out Vector3[] points) {
        points = new Vector3[] { m_pointStart.m_position, m_pointMiddle.m_position, m_pointEnd.m_position };
    }

    public void GetStartPoint(out Vector3 position, out Quaternion rotation)
    {
        position = m_pointStart.m_position;
        rotation = m_pointStart.m_rotation;
    }
    public void GetMiddlePoint(out Vector3 position, out Quaternion rotation)
    {
        position = m_pointMiddle.m_position;
        rotation = m_pointMiddle.m_rotation;
    }
    public void GetEndPoint(out Vector3 position, out Quaternion rotation)
    {
        position = m_pointEnd.m_position;
        rotation = m_pointEnd.m_rotation;
    }


    public void GetMiddleAsOrigineCross(out Vector3 origineStart, out Vector3 axeADirection, out Vector3 axeBDirection) {
        axeADirection = m_pointStart.m_position - m_pointMiddle.m_position;
        axeBDirection = m_pointEnd.m_position - m_pointMiddle.m_position;
        origineStart = m_pointMiddle.m_position;
    }

    public float GetBordersLenght()
    {
        return Vector3.Distance(m_pointStart.m_position, m_pointMiddle.m_position) +
            Vector3.Distance(m_pointMiddle.m_position, m_pointEnd.m_position) +
            Vector3.Distance(m_pointEnd.m_position, m_pointStart.m_position) ;
    }

    public void GetMiddleAsOrigineCartesian(out Vector3 startPosition, out Vector3 rightDirection, out Vector3 upDirection, out Vector3 forwardDirection)
    {
        GetMiddleAsOrigineCross(out startPosition, out Vector3 axeA, out Vector3 axisB);
        upDirection = Vector3.Cross(axeA, axisB).normalized;
        rightDirection = Vector3.Cross(upDirection, axeA).normalized;
        forwardDirection = Vector3.Cross(rightDirection, upDirection).normalized;
    }
    public void GetMiddleAsOrigineCartesian(out Vector3 startPosition, out Vector3 rightDirection, out Vector3 upDirection, out Vector3 forwardDirection, out Quaternion cartesianOrientation)
    {
        GetMiddleAsOrigineCartesian(out startPosition, out rightDirection, out upDirection, out forwardDirection);
        cartesianOrientation = Quaternion.LookRotation(forwardDirection, upDirection);
    }
    public void GetMiddleAsOrigineCartesian(out Vector3 startPosition,  out Quaternion cartesianOrientation)
    {
        GetMiddleAsOrigineCartesian(out startPosition, out Vector3 rightDirection, out Vector3 upDirection, out Vector3 forwardDirection);
        cartesianOrientation = Quaternion.LookRotation(forwardDirection, upDirection);
    }

    public float GetStartAngle()
    {
        Vector3 dirA = m_pointMiddle.m_position - m_pointStart.m_position;
        Vector3 dirB = m_pointEnd.m_position - m_pointStart.m_position;
        return Vector3.Angle(dirA, dirB);
    }

    public float GetMiddleAngle()
    {
        Vector3 dirA = m_pointStart.m_position - m_pointMiddle.m_position;
        Vector3 dirB = m_pointEnd.m_position - m_pointMiddle.m_position;
        return Vector3.Angle(dirA, dirB);
    }

    public float GetEndAngle()
    {
        Vector3 dirA = m_pointStart.m_position - m_pointEnd.m_position;
        Vector3 dirB = m_pointMiddle.m_position - m_pointEnd.m_position;
        return Vector3.Angle(dirA, dirB);
    }

    public float GetStartMiddleDistance()
    {
        return Vector3.Distance(m_pointStart.m_position, m_pointMiddle.m_position);
    }

    public float GetMiddleEndDistance()
    {
        return Vector3.Distance(m_pointEnd.m_position, m_pointMiddle.m_position);
    }

    public float GetStartEndDistance()
    {
        return Vector3.Distance(m_pointStart.m_position, m_pointEnd.m_position);
    }

    public void GetCenterCentroid(out Vector3 point)
    {
        point = Vector3.zero;
        point += m_pointMiddle.m_position;
        point += m_pointStart.m_position;
        point += m_pointEnd.m_position;
        point /= 3;
    }
    public void GetCenterIncenter(out Vector3 point)
    {
        //Get Center https://www.math.stonybrook.edu/~scott/mat360.spr04/cindy/various.html#:~:text=The%20centroid%20of%20a%20triangle,triangle%20meet%20at%20the%20circumcenter.
        throw new NotImplementedException();
    }
    public void GetCenterOrthocenter(out Vector3 point)
    {
        //Get Center https://www.math.stonybrook.edu/~scott/mat360.spr04/cindy/various.html#:~:text=The%20centroid%20of%20a%20triangle,triangle%20meet%20at%20the%20circumcenter.
        throw new NotImplementedException();
    }
    public void GetCenterCircumcenter(out Vector3 point)
    {
        //Source: https://gamedev.stackexchange.com/questions/60630/how-do-i-find-the-circumcenter-of-a-triangle-in-3d
        //Unity/C#
        Vector3 ac = m_pointStart.m_position - m_pointMiddle.m_position;
        Vector3 ab = m_pointEnd.m_position - m_pointMiddle.m_position;
        Vector3 abXac = Vector3.Cross(ab, ac);

        // this is the vector from a TO the circumsphere center
        Vector3 toCircumsphereCenter = (Vector3.Cross(abXac, ab) * ac.sqrMagnitude + Vector3.Cross(ac, abXac) * ab.sqrMagnitude) / (2f * abXac.sqrMagnitude);
        float circumsphereRadius = toCircumsphereCenter.magnitude;

        // The 3 space coords of the circumsphere center then:
        Vector3 ccs = m_pointMiddle.m_position + toCircumsphereCenter; // now this is the actual 3space location
        point = ccs;
    }
}



[System.Serializable]
public class ThreePointsCalibrationEvent: UnityEvent<ThreePointsCalibration>
{}



[System.Serializable]
public class ThreePointsLenghtAndAngleAnchor
{
    public float m_totalLenght;
    public float m_startToMiddleLenght;
    public float m_endToMiddleLenght;
    public float m_endToStartLenght;
    public float m_startAngle;
    public float m_middleAngle;
    public float m_endAngle;
    public bool IsAlmostEqualTo(ThreePointsLenghtAndAngleAnchor id, float precisionRadiusInMeter, float precisionRadiusInAngle)
    {
        float tl = Mathf.Abs(this.m_startToMiddleLenght - id.m_startToMiddleLenght);
        float sml = Mathf.Abs(this.m_endToMiddleLenght - id.m_endToMiddleLenght);
        float eml = Mathf.Abs(this.m_endToStartLenght - id.m_endToStartLenght);
        float sa = Mathf.Abs(this.m_startAngle - id.m_startAngle);
        float ma = Mathf.Abs(this.m_middleAngle - id.m_middleAngle);
        float ea = Mathf.Abs(this.m_endAngle - id.m_endAngle);
        return tl <= precisionRadiusInMeter &&
            sml <= precisionRadiusInMeter &&
            eml <= precisionRadiusInMeter &&
            sa <= precisionRadiusInAngle &&
            ma <= precisionRadiusInAngle &&
            ea <= precisionRadiusInAngle;
    }
}
[System.Serializable]
public class ThreePointsAxisLenghtAnchor
{
    public float m_totalLenght;
    public float m_startToMiddleLenght;
    public float m_endToMiddleLenght;

    public bool IsAlmostEqualTo(ThreePointsAxisLenghtAnchor id, float precisionRadiusInMeter)
    {
        float tl = Mathf.Abs(this.m_totalLenght - id.m_totalLenght);
        float sml = Mathf.Abs(this.m_startToMiddleLenght - id.m_startToMiddleLenght);
        float eml = Mathf.Abs(this.m_endToMiddleLenght - id.m_endToMiddleLenght);
        return tl <= precisionRadiusInMeter &&
            sml <= precisionRadiusInMeter &&
            eml <= precisionRadiusInMeter;
    }
}

[System.Serializable]
public class ThreePointsCartesianAnchor
{
    public float m_forwardAxeLenght;
    public float m_freeAxeLenght;
    public float m_axisAngle;
    public bool IsAlmostEqualTo(ThreePointsCartesianAnchor id, float precisionRadiusInMeter, float precisionRadiusInAngle)
    {
        float tl = Mathf.Abs(this.m_forwardAxeLenght - id.m_forwardAxeLenght);
        float sml = Mathf.Abs(this.m_freeAxeLenght - id.m_freeAxeLenght);
        float eml = Mathf.Abs(this.m_axisAngle - id.m_axisAngle);
        return tl <= precisionRadiusInMeter &&
            sml <= precisionRadiusInMeter &&
            eml <= precisionRadiusInAngle;
    }
}



[System.Serializable]
public class ThreePointsCalibrationWithLinkedId
{
    public string m_linkedAliadIdName;
    public ThreePointsCalibration m_threePointsGiven;
}
[System.Serializable]
public class ThreePointsCalibrationWithLinkedIdEvent: UnityEvent<ThreePointsCalibrationWithLinkedId>
{
}