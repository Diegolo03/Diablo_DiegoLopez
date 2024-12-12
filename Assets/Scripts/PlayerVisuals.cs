using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    private Animator anim;
    [SerializeField] NavMeshAgent agent;
    private void Awake()
    {

        anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}