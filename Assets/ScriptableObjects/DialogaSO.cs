using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogos")]
public class DialogaSO : ScriptableObject
{
    [TextArea]
    public string[] frases;
    public AudioClip[] frasesClip;
    public float delay;

    public bool tieneMision;

    public MisionSO mision;
}
