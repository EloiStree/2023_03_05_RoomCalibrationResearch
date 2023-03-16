using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_NotMovingDetection
{

    public static void IsTwoPointConsiderAsMoved(Vector3 currentPositoin, Vector3 notMovingOriginPosition, float rangeOfNotMovingZone, out bool isConsiderAsMoved)
    {
        isConsiderAsMoved = (currentPositoin - notMovingOriginPosition).magnitude >= rangeOfNotMovingZone;
    }
    public static void IsTwoPointConsiderAsRotated(Quaternion currentRotation, Quaternion notRotatingOriginRotation, float angleOfNotRotatingZone, out bool isConsiderAsRotated)
    {
        isConsiderAsRotated = Mathf.Abs(Quaternion.Angle(currentRotation, notRotatingOriginRotation)) >= angleOfNotRotatingZone;
    }


}
