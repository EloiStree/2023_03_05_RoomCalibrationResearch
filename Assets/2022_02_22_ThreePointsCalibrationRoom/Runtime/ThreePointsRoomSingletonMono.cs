using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePointsRoomSingletonMono : MonoBehaviour
{
    public ThreePointsCalibrationEvent m_onThreePointsCalibrationChanged ;
    public bool m_loadCurrentAtAwake=true;

    private void Awake()
    {
        if(m_loadCurrentAtAwake)
            NotifyChanged(ThreePointsRoomSingleton.GetCurrentRoomCalibration());
    }
    public void SetWith(ThreePointsCalibration threePointCalibration) {
        ThreePointsRoomSingleton.SetCurrentRoomCalibration(threePointCalibration);
    }

    [ContextMenu("Force repush")]
    public void ForceRepush() {
            NotifyChanged(ThreePointsRoomSingleton.GetCurrentRoomCalibration());


    }
    private void OnEnable()
    {
        ThreePointsRoomSingleton.AddChangeListener(NotifyChanged);
    }
    private void OnDisable()
    {
        ThreePointsRoomSingleton.RemoveChangeListener(NotifyChanged);
    }

    private void NotifyChanged(ThreePointsCalibration newCalibration)
    {
        m_onThreePointsCalibrationChanged.Invoke(newCalibration);
    }
}
public class ThreePointsRoomSingleton 
{
    static ThreePointsCalibration m_currentthreePoints= new ThreePointsCalibration();
    static ThreePointsCalibrationChangedDelegate m_onCalibrationChanged=null;
    public delegate void ThreePointsCalibrationChangedDelegate(ThreePointsCalibration newCalibration);

    public static ThreePointsCalibration GetCurrentRoomCalibration()
    {
        return m_currentthreePoints;
    }
    public static void SetCurrentRoomCalibration(ThreePointsCalibration threePointCalibration)
    {
        m_currentthreePoints = threePointCalibration;
        m_onCalibrationChanged.Invoke(threePointCalibration);
    }
    public static void AddChangeListener(ThreePointsCalibrationChangedDelegate listener)
    {
        m_onCalibrationChanged += listener;
    }
    public static void RemoveChangeListener(ThreePointsCalibrationChangedDelegate listener)
    {
        m_onCalibrationChanged -= listener;
    }

   

}
