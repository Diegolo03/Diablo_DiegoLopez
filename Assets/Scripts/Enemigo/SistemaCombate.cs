using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate, distanciaAtaque;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    private void Awake()
    {
        main.Combate = this;
    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(main.MainTarget.position);
    }
    
       
            
           
}
