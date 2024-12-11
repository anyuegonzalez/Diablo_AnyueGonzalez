using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    private void Awake()
    {
        // referencio al animator
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}
