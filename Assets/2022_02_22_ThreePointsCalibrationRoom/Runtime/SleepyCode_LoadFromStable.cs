using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepyCode_LoadFromStable : MonoBehaviour
{

    public Transform m_trackPoint;

    public List<PointRecorded> m_pointsRecorded = new List<PointRecorded>();


    public TwoPointsCalibration m_twoPointsCalibration;
    public TwoPointsCalibrationEvent m_onTwoPointsCalibrationFound;

    public ThreePointsCalibration m_threePointsCalibration;
    public ThreePointsCalibrationEvent m_onThreePointsCalibrationFound;
    public int m_maxHistoryCount=3;


    [System.Serializable]
    public class PointRecorded {
        public Vector3 m_position;
        public Quaternion m_rotation;
    }

    [ContextMenu("Save track point")]
    public void SaveTrackPoint() {

        m_pointsRecorded.Insert(0, new PointRecorded() { m_position = m_trackPoint.position, m_rotation= m_trackPoint.rotation });
        while (m_pointsRecorded.Count > m_maxHistoryCount) {
            m_pointsRecorded.RemoveAt(m_pointsRecorded.Count - 1);
        }
        if (m_pointsRecorded.Count == 2)
        {
            m_twoPointsCalibration.m_positionStart = m_pointsRecorded[0].m_position;
            m_twoPointsCalibration.m_rotationStart = m_pointsRecorded[0].m_rotation;
            m_twoPointsCalibration.m_positionEnd = m_pointsRecorded[1].m_position;
            m_twoPointsCalibration.m_rotationEnd = m_pointsRecorded[1].m_rotation;
            m_onTwoPointsCalibrationFound.Invoke(m_twoPointsCalibration);
        }
        if (m_pointsRecorded.Count == 3)
        {
            m_threePointsCalibration.m_pointStart.m_position = m_pointsRecorded[0].m_position;
            m_threePointsCalibration.m_pointStart.m_rotation = m_pointsRecorded[0].m_rotation;
            m_threePointsCalibration.m_pointMiddle.m_position = m_pointsRecorded[1].m_position;
            m_threePointsCalibration.m_pointMiddle.m_rotation = m_pointsRecorded[1].m_rotation;
            m_threePointsCalibration.m_pointEnd.m_position = m_pointsRecorded[2].m_position;
            m_threePointsCalibration.m_pointEnd.m_rotation = m_pointsRecorded[2].m_rotation;
            m_onThreePointsCalibrationFound.Invoke(m_threePointsCalibration);
        }
    }



}
