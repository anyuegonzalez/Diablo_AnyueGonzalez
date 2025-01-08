using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private NavMeshAgent agent;


    private void Awake()
    {
        main.Combate = this;
    }
    void Start()
    {
       
    }
    void Update()
    {
        agent.speed = velocidadCombate;
        agent.SetDestination(main.MainTarget.position);
    }
}
