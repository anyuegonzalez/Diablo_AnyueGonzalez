using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    [SerializeField] private float distanciaInteraccion;

    private NavMeshAgent agent;
    private Camera cam;

    // guardo informacion del npc actual con el que voy a hablar
    private Transform ultimoClick;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;

    }
    void Update()
    {
        if(Time.timeScale == 1) // si no estamos en pausa
        {
            Movimiento();
        }
        

        // si existe un npc al cual clike
        if(ultimoClick  && ultimoClick.TryGetComponent(out Npc npc))
        {
            agent.stoppingDistance = distanciaInteraccion;
            // comprobar si ha llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npc.Interactuar(this.transform); // el transform es un gameobject, es porq hemos puesto Transform en el codigo de npc
                ultimoClick = null;
            }
        }
        else if(ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
       
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
}
