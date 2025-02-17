using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour,IInteractuable
{
    private Outline outline;
    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;

    [SerializeField] private DialogaSO dialogo1;
    [SerializeField] public DialogaSO dialogo2;
    [SerializeField] private MisionSO misionAsociada;
    public DialogaSO dialogoActual;
    [SerializeField] private float tiemporotacion;
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private SistemaDialogo sD;
    [SerializeField] private EventManagerSO eventManager;

    public DialogaSO DialogoActual { get => dialogoActual; set => dialogoActual = value; }
    public DialogaSO Dialogo2 { get => dialogo2; set => dialogo2 = value; }

    public void Interactuar(Transform interactuador)
    {
 
        transform.DOLookAt(interactuador.position, tiemporotacion, AxisConstraint.Y).OnComplete(() => SistemaDialogo.sistema.IniciarDialogo(dialogoActual, cameraPoint));
        
    }

    

    // Start is called before the first frame update
    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (misionTerminada == misionAsociada)
        {
            dialogoActual = dialogo2;

            //SceneManager.LoadScene(1);
        }
    }

    private void Awake()
    {
        dialogoActual = dialogo1;
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
