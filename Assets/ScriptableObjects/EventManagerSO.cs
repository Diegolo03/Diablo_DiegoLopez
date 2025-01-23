using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNuevaMision;
    public void NuevaMision()
    {
       OnNuevaMision.Invoke();
    }
}
