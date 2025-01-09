using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Animator anim;
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
        if (main.MainTarget && agent.CalculatePath(main.MainTarget.position, new NavMeshPath())) 
        {
            agent.SetDestination(main.MainTarget.position);
            if (agent.remainingDistance==0)
            {
                anim.SetBool("Atacar", true);

            }
            else
            {
                anim.SetBool("Atacar", false);
            }
        }
        else
        {
            main.ActivarPatrulla();
            this.enabled = false;
        }
    }
    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;
    }



}
