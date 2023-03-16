using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePointsDrawsDebugCartesianInfoMono : MonoBehaviour
{
    public ThreePointsCalibration m_threePoints;
    public Color pointsLineToGround;

    public void SetThreePoints(ThreePointsCalibration calibration) {

        m_threePoints = calibration;
    }
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 positionOrigine = Vector3.zero;
        m_threePoints.GetMiddlePoint(out  positionOrigine, out Quaternion q);
        Eloi.E_DrawingUtility.DrawCartesianOrigine(positionOrigine - positionOrigine, Quaternion.identity, 0.5f, dt);
        Eloi.E_DrawingUtility.DrawLines(dt, pointsLineToGround, positionOrigine, -positionOrigine);

        //Vector3 position; 
        Quaternion rotation;
        m_threePoints.GetMiddlePoint(out Vector3 middle, out  rotation);
        Vector3 flatMiddle = middle;
        flatMiddle.y = 0;
        m_threePoints.GetStartPoint(out Vector3 start, out  rotation);
        Vector3 flatStart = start;
        flatStart.y = 0;
        m_threePoints.GetEndPoint(out Vector3 end, out  rotation);
        Vector3 flatEnd = end;
        flatEnd.y = 0;


        Eloi.E_DrawingUtility.DrawLines(dt, pointsLineToGround, middle, flatMiddle);
        Eloi.E_DrawingUtility.DrawLines(dt, pointsLineToGround, end, flatEnd);
        Eloi.E_DrawingUtility.DrawLines(dt, pointsLineToGround, start, flatStart);
        Eloi.E_DrawingUtility.DrawLines(dt, pointsLineToGround, flatStart,  flatMiddle, flatEnd, flatStart);
    }
}
