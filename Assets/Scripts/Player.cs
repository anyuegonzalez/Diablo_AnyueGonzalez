using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Player : MonoBehaviour, IDanhable
{

    [SerializeField] private float vidas = 200;
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float tiempoRotacion;

    [SerializeField] private float attackingDistance = 2f;
    [SerializeField] private float danhoAtaque = 10f;

    private Transform lastHit;

    private Transform currentTarget;
    private PlayerVisualSystem1 visualSystem;

    private NavMeshAgent agent;
    private Camera cam;

    // guardo informacion del npc actual con el que voy a hablar
    private Transform ultimoClick;

    private PlayerAnimation playerAnimations;

    public PlayerAnimation PlayerAnimations { get => playerAnimations; set => playerAnimations = value; }
    public PlayerVisualSystem1 VisualSystem { get => visualSystem; set => visualSystem = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;

    }
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0) //Porque si no, "recuerda" hits hechos en pausa.
            {
                agent.SetDestination(hit.point);
                lastHit = hit.transform;
            }
        }

        if (lastHit)
        {
            visualSystem.StopAttacking();

            if (lastHit.TryGetComponent(out IInteractuable interactable))
            {
                agent.stoppingDistance = distanciaInteraccion;
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    interactable.Interactuar(transform);
                    lastHit = null; //Para que no siga interactuando
                }
            }
            else if (lastHit.TryGetComponent(out IDanhable interactuador))
            {
                currentTarget = lastHit;
                agent.stoppingDistance = attackingDistance;
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    visualSystem.StartAttacking();
                }
            }
            else
            {
                agent.stoppingDistance = 0f;
            }
        }
        if (Time.timeScale == 1)
        {
            Movimiento();
        }
        
        // si existe un npc al cual clike
        if(ultimoClick  && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance = distanciaInteraccion;
            // comprobar si ha llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {  
               LanzarInteraccion(interactuable);  
            }
        }
        else if(ultimoClick && ultimoClick.TryGetComponent(out Enemigo enemigo))
        {

        }
        else if(ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
       
    }
    private void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(this.transform); // el transform es un gameobject, es porq hemos puesto Transform en el codigo de npc
        ultimoClick = null;
    }
    private void Movimiento()
    {
        // trazar un raycast desde la camara a la posicion del raton
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(hit.point);
                ultimoClick = hit.transform;
            }

        }
    }
    private void FaceTarget()
    {
        Vector3 directionToTarget = (currentTarget.transform.position - transform.position).normalized;
        directionToTarget.y = 0f;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = rotationToTarget;
    }
    public void Atacar()
    {
        currentTarget.GetComponent<IDanhable>().RecibirDanho(danhoAtaque);
    }
    public void RecibirDanho(float danho)
    {
        vidas -= danho;
        if (vidas <= 0)
        {
            Destroy(this);
            visualSystem.EjecutarAnimacionMuerte();
        }
    }

}
