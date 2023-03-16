using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtCenterOfThreePointsFacingMidMono : MonoBehaviour
{
    public ThreePointsCalibration m_threePoints;
    public Transform m_centroid;
    public Transform m_circumcenter;
    //public Transform m_incenter;
    //public Transform m_orthocenter;

    public void SetWith(ThreePointsCalibration points) {
        m_threePoints = points;
        points.GetMiddlePoint(out Vector3 mid, out Quaternion rotation);

        if (m_centroid != null) { 
        points.GetCenterCentroid(out Vector3 centroid);
        m_centroid.position = centroid;
        m_centroid.rotation = Quaternion.LookRotation(mid - centroid, Vector3.up);
        }
        if (m_circumcenter != null)
        {

            points.GetCenterCircumcenter(out Vector3 centroid);
            m_circumcenter.position = centroid;
            m_circumcenter.rotation = Quaternion.LookRotation(mid - centroid, Vector3.up);
        }
        //points.GetCenterIncenter(out  centroid);
        //m_incenter.position = centroid;
        //points.GetCenterOrthocenter(out  centroid);
        //m_orthocenter.position = centroid;

    }

}
