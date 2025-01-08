using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;
    [SerializeField] private DialogaSO dialogo;
    [SerializeField] private float tiemporotacion;
    [SerializeField] private Transform cameraPoint;
    public void Interactuar(Transform interactuador)
    {
        Debug.Log("Hola");
        transform.DOLookAt(interactuador.position, tiemporotacion, AxisConstraint.Y).OnComplete(() => SistemaDialogo.sistema.IniciarDialogo(dialogo, cameraPoint));
        
    }

    

    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnMouseEnter()
    {

        Cursor.SetCursor(cursorInteraccion, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;

    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }

}
