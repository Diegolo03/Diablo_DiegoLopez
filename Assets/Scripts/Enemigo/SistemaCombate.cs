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
    [SerializeField] private float velocidadCombate, distanciaAtaque,danhoAtaque;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Collider col;
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
        if (main.MainTarget!=null && agent.CalculatePath(main.MainTarget.position, new NavMeshPath())) 
        {
            agent.SetDestination(main.MainTarget.position);
            if (!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("Atacar", true);

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
    #region Ejectados por eventos de animacion
    private void Atacar()
    {
        main.MainTarget.GetComponent<Player>().HacerDanho(danhoAtaque);
    }
    private void FinDeAtaque()
    {
        anim.SetBool("Atacar", false);
    }
    #endregion

}
