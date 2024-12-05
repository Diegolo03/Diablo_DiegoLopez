using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogos")]
public class DialogaSO : ScriptableObject
{
    [TextArea]
    public string[] frases;
    public float delay;
    
}
