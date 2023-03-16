using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoPointsCalibrationMono : MonoBehaviour
{
    public TwoPointsCalibration m_calibrationPoints;
    public float m_magnitude;
    public Vector3 m_direction;
    public bool m_useDraw;

    public void SetTwoPoints(TwoPointsCalibration calibrationPoints) {
        m_calibrationPoints = calibrationPoints;
        m_direction = calibrationPoints.GetDirection();
        m_magnitude = calibrationPoints.GetMagnitude();
    }

    public void Update()
    {
        if (m_useDraw) { 
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, Color.yellow, m_calibrationPoints.m_positionStart, m_calibrationPoints.m_positionEnd);
            Eloi.E_DrawingUtility.DrawCartesianOrigine(m_calibrationPoints.m_positionStart, m_calibrationPoints.m_rotationStart, 0.1f, Time.deltaTime);  
        }
    }
}


[System.Serializable]
public class TwoPointsCalibration {

        public Vector3 m_positionStart;
        public Quaternion m_rotationStart;
        public Vector3 m_positionEnd;
        public Quaternion m_rotationEnd;

    public Vector3 GetDirection()
    {
        return m_positionEnd - m_positionStart;
    }
    public Quaternion GetStartOrientation()
    {
        return m_rotationStart;
    }
    public Vector3 GetStartPosition()
    {
        return m_positionStart;
    }

    public float GetMagnitude()
    {
        return Vector3.Distance(m_positionStart, m_positionEnd);
    }
}


[System.Serializable]
public class TwoPointsCalibrationEvent: UnityEvent<TwoPointsCalibration>
{}


[System.Serializable]
public class TwoPointsCalibrationWithId
{   
    public string m_calibrationNamedId;
    public TwoPointsCalibration m_calibrationPoints;

    public string GetAsJson() { return JsonUtility.ToJson(this); }
    public void SetFromJson(string json) { TwoPointsCalibrationWithId created=  JsonUtility.FromJson<TwoPointsCalibrationWithId>(json);
        this.m_calibrationNamedId = created.m_calibrationNamedId;
        this.m_calibrationPoints = created.m_calibrationPoints;
    }

}
