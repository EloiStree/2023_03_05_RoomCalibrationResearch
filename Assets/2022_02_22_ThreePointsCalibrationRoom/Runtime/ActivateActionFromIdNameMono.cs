using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateActionFromIdNameMono : MonoBehaviour
{

    public StringToActivation[] m_aliasToActivate;
    public Eloi.PrimitiveUnityEvent_String m_onActivationFound;

    [System.Serializable]
    public class StringToActivation {
        public string m_aliadId;
        public Eloi.PrimitiveUnityEventExtra_Bool m_onFound;
    }



    public void TryToSwitch(string name) {

        foreach (var item in m_aliasToActivate)
        {
            bool isToActive = item.m_aliadId.Trim().ToLower() == name.Trim().ToLower();
            item.m_onFound.Invoke(isToActive);
            m_onActivationFound.Invoke(name);
        }
    }
}
