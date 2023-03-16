using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAlmostStableSinceMono : MonoBehaviour
{
    public IsAlmostStableMono m_tracker;
    public float m_timeToActivate = 2;

    public BooleanChangeObserver m_isStable;
    public Eloi.PrimitiveUnityEventExtra_Bool m_onIsStableChanged;

    void Update()
    {
        bool value = m_tracker.m_stableTimer >= m_timeToActivate;
        m_isStable.SetBoolean(in value, out bool changed);
        if (changed)
            m_onIsStableChanged.Invoke(value);

    }
}
