using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;
    private NPC npcActual;
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
        InteractuarYMover();
        
        if (npcActual)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {

                npcActual.Interactuar(this.transform);
                npcActual = null;
                
                agent.isStopped = true;
                agent.stoppingDistance = 0;
            }
        }

    }

    private void InteractuarYMover()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    npcActual = npc;
                    agent.stoppingDistance = distanciaInteraccion;
                }

                agent.SetDestination(hit.point);

            }

        }
    }
}
