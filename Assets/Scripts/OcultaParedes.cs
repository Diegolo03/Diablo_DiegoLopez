using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OcultaParedes : MonoBehaviour
{
    [SerializeField] private Renderer[] paredes;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Renderer pared in paredes)
            {
                pared.enabled = false;
               //Color nuevoColor =pared.material.color;
               // nuevoColor.a = 0.0001f;
               // pared.material.color = nuevoColor;

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Renderer pared in paredes)
            {
                pared.enabled = true;
                

            }
        }
    }
}
