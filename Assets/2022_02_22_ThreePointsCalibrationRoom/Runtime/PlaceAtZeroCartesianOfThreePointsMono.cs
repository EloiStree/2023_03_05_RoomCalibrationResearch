using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtZeroCartesianOfThreePointsMono : MonoBehaviour
{
    public ThreePointsCalibration m_threePoints;
    public Transform m_toMove;

    public void SetWith(ThreePointsCalibration points)
    {
        m_threePoints = points;
        points.GetMiddleAsOrigineCartesian(out Vector3 cartesianPosition, out Quaternion rotation);

        m_toMove.position = cartesianPosition- cartesianPosition;
        m_toMove.rotation = Quaternion.Inverse( rotation);


    }

}
