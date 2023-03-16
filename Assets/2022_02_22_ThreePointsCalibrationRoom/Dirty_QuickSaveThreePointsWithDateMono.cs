using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirty_QuickSaveThreePointsWithDateMono : MonoBehaviour
{

    public Eloi.AbstractMetaAbsolutePathDirectoryMono m_directoryPath;
    public string m_fileName = "ThreePointsCoordinate";
    public string m_dateFormat = "YYYYMMDDTHHmmss";

    public void Save(string text) {

        Eloi.MetaFileNameWithExtension f = new Eloi.MetaFileNameWithExtension(m_fileName, "json");
        Eloi.IMetaAbsolutePathFileGet file =  Eloi.E_FileAndFolderUtility.Combine(m_directoryPath, f);
        Eloi.E_FileAndFolderUtility.ExportByOverriding(file, text);
    }
}
