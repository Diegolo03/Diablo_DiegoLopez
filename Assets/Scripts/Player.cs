using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;
    private Transform ultimoClick;
    [SerializeField]private float distanciaInteraccion;

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
       
        
        if (ultimoClick&&ultimoClick.TryGetComponent(out NPC npc))
        {
            
            agent.stoppingDistance = distanciaInteraccion;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {

                npc.Interactuar(this.transform);
                ultimoClick = null;
                
                
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0;
        }

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
}
