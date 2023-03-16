using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class ThreePointsCalibrationWithLinkedIdMono : MonoBehaviour
{
    public ThreePointsCalibrationWithLinkedId m_systemId;
    public UnityEvent m_onSystemChanged;
    public Eloi.PrimitiveUnityEvent_String m_onSystemChangedName;
    public ThreePointsCalibrationEvent m_onSystemChangedPoints;

    public void SetSystemIdFound(ThreePointsCalibrationWithLinkedId systemId) {

        m_systemId = systemId;
        m_onSystemChanged.Invoke();
        m_onSystemChangedName.Invoke(m_systemId.m_linkedAliadIdName);
        m_onSystemChangedPoints.Invoke(m_systemId.m_threePointsGiven);
    }
    public void SetSystemIdFound(string id, ThreePointsCalibration threePoint)
    {

        SetSystemIdFound(new ThreePointsCalibrationWithLinkedId() {m_linkedAliadIdName = id, m_threePointsGiven= threePoint });

    }
}
