using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTriangleZoneOfThreePointsMono : MonoBehaviour
{
    public ThreePointsCalibration m_threePoints;
    public Transform m_groundMiddle;
    public Transform m_groundStart;
    public Transform m_groundEnd;

    public Transform m_pointMiddle;
    public Transform m_pointStart;
    public Transform m_pointEnd;

    public Transform m_cartesianMiddle;
    public Transform m_cartesianStart;
    public Transform m_cartesianEnd;
    public void SetThreePoints(ThreePointsCalibration calibration)
    {

        m_threePoints = calibration;
    
        float dt = Time.deltaTime;
        Vector3 positionOrigine = Vector3.zero;
        m_threePoints.GetMiddlePoint(out positionOrigine, out Quaternion q);

        //Vector3 position; 
        Quaternion rotation;
        m_threePoints.GetMiddlePoint(out Vector3 middle, out rotation);
        Vector3 flatMiddle = middle;
        flatMiddle.y = 0;
        m_threePoints.GetStartPoint(out Vector3 start, out rotation);
        Vector3 flatStart = start;
        flatStart.y = 0;
        m_threePoints.GetEndPoint(out Vector3 end, out rotation);
        Vector3 flatEnd = end;
        flatEnd.y = 0;


        m_threePoints.GetMiddleAsOrigineCartesian(out Vector3 startPoint, out Vector3 r, out Vector3 u, out Vector3 f, out Quaternion catesianDirection);

        Quaternion wq = Quaternion.identity;
        Vector3 wp = positionOrigine - positionOrigine;
        Eloi.E_DrawingUtility.DrawCartesianOrigine(positionOrigine - positionOrigine, wq, 0.5f, dt);
        m_cartesianMiddle.position = wp;
        m_cartesianStart.position = wp + wq * Vector3.forward;
        m_cartesianEnd.position = wp + wq * Vector3.right;


        m_groundMiddle.position = flatMiddle;
        m_groundStart.position = flatStart;
        m_groundEnd.position = flatEnd;

        m_pointMiddle.position = middle;
        m_pointStart.position = start;
        m_pointEnd.position = end;
    }
}
