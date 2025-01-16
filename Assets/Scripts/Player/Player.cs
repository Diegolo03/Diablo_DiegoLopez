using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;
    private Transform ultimoClick;
    [SerializeField]private float distanciaInteraccion,vidas;
    private float tiemporotacion=1;
    //private bool iniciar;

    // Start is called before the first frame update
    void Start()
    {

        cam=Camera.main;
        agent =GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale ==1)
        {
            InteractuarYMover();
        }
       
        
        if (ultimoClick&&ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            
            agent.stoppingDistance = distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) 
            {

                //transform.DOLookAt(interactuable.transform.position,tiemporotacion, AxisConstraint.Y).OnComplete(() => */LanzarInteraccion(interactuable));
                LanzarInteraccion(interactuable);
                //iniciar = false;




            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0;
        }

    }
    private void LanzarInteraccion(IInteractuable interactuable)
    {
        //if (!iniciar)
        //{
            //iniciar=true;
            interactuable.Interactuar(transform);
            ultimoClick = null;

        //}
    }
    
    private void InteractuarYMover()
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                
                agent.SetDestination(hit.point);
                ultimoClick=hit.transform;
            }

        }
    }
    public void HacerDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
    }
}
