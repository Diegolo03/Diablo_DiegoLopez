using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private Transform ruta;
    [SerializeField] private NavMeshAgent agent;
    private Vector3 destinoActual;
    List<Vector3> listadoPuntos = new List<Vector3>();
    private int indiceRutaActual=-1;
    [SerializeField] private float velocidadPatrulla, distanciaPatrulla;

    // Start is called before the first frame update
    private void Awake()
    {
        main.Patrulla = this;
        foreach (Transform punto in ruta)
        {
            listadoPuntos.Add(punto.position);
        }
        
    }
    private void OnEnable()
    {
        indiceRutaActual = -1;
        agent.speed = velocidadPatrulla;
        agent.stoppingDistance = distanciaPatrulla;
        StartCoroutine(PatrullarYEsperar());
    }
    void Start()
    {
       
       
    }

    // Update is called once per frame
    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            CalcularDestino();
            agent.SetDestination(destinoActual);
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= 0.2f);
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        }
    }
    private void CalcularDestino()
    {
        indiceRutaActual++;
        if (indiceRutaActual >= listadoPuntos.Count)
        {
            indiceRutaActual = 0;
        }
            destinoActual = listadoPuntos[indiceRutaActual];
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            main.ActivarCombate(other.transform);
            this.enabled=false;
        }
    }
}
