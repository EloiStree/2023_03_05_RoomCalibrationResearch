using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadThreePointsCalibrationMono : MonoBehaviour
{
    public ThreePointsCalibration m_importedThreePoints;

    public ThreePointsCalibrationEvent m_onImported;
    public string m_givenJsonToTryToImport;

    [ContextMenu("Load from Interface")]
    public void LoadFromInspector()
    {
        Load(m_givenJsonToTryToImport);
    }
    public void Load(string jsonTextToConvert)
    {
        if (jsonTextToConvert.Trim().Length == 0)
            return;
        m_givenJsonToTryToImport = jsonTextToConvert;
        m_importedThreePoints = JsonUtility.FromJson<ThreePointsCalibration>(m_givenJsonToTryToImport);
        m_onImported.Invoke(m_importedThreePoints);
    }
}
