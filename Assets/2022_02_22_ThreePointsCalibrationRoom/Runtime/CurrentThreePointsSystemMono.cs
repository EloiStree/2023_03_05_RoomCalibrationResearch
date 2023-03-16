using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrentThreePointsSystemMono : MonoBehaviour
{
    public ThreePointsCalibration m_calibrationPoints;


    public ThreePointsAxisLenghtAnchor m_axisGivenId;
    public ThreePointsAxisLenghtAnchorId [] m_axisActiveId;
    public float m_precesionToBeValideInMeter=0.03f;

    public bool m_idAreAlmostEquals;
    public ThreePointsCalibrationWithLinkedIdEvent m_onSystemFound;

    public void SetThreePoints(ThreePointsCalibration calibrationPoints) {

        m_calibrationPoints = calibrationPoints;
        m_axisGivenId.m_startToMiddleLenght = m_calibrationPoints.GetStartMiddleDistance();
        m_axisGivenId.m_endToMiddleLenght = m_calibrationPoints.GetMiddleEndDistance();
        m_axisGivenId.m_totalLenght = m_calibrationPoints.GetBordersLenght();

        foreach (var item in m_axisActiveId)
        {
            bool isEquals = m_axisGivenId.IsAlmostEqualTo(item.m_calibrationValues, m_precesionToBeValideInMeter);
            if (isEquals)
            {
                m_onSystemFound.Invoke(new ThreePointsCalibrationWithLinkedId() { m_linkedAliadIdName = item.m_nameAliasId, m_threePointsGiven = m_calibrationPoints });
            }
        }
    }
   
}


[System.Serializable]
public class ThreePointsAxisLenghtAnchorId {

    public string m_nameAliasId;
    public ThreePointsAxisLenghtAnchor m_calibrationValues;

}

[System.Serializable]
public class ThreePointsAxisLenghtAnchorIdEvent : UnityEvent<ThreePointsAxisLenghtAnchorId> { 


}