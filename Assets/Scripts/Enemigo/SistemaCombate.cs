using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private NavMeshAgent agent;


    private void Awake()
    {
        main.Combate = this;
    }
    // se ejecuta despues del awake y solo cuando el script es habilitado, se puede ejecutar varias veces, cada vez que lo habilitas
    // el combate ha sido habilitado 
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }

    void Start()
    {
       
    }
    void Update()
    {    
        agent.SetDestination(main.MainTarget.position);
    }
}
