using System;
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

    [SerializeField] private Animator anim;

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
    void Update()
    {

        // si el target es alcanzable y ese target es alcanzable... 
        if(main.MainTarget != null && agent.CalculatePath(main.MainTarget.position, new NavMeshPath()))
        {
            EnfocarObjetivo();
            // voy persiguiendo al target en todo momento (calculando su posicion)
            agent.SetDestination(main.MainTarget.position);

            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("attacking", true);
            }
          
        }
        else // si no es alcanzable
        {
            main.ActivarPatrulla();
        }
        
    }
    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;

    }
    #region Ejecutados por eventos de animacion
    private void Atacar()
    {

    }
    private void FinAnimacionAtaque()
    {

    }
    #endregion

}
