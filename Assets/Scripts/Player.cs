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
    private Npc npcActual;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;

    }
    void Update()
    {
        Movimiento();

        // si existe un npc al cual clike
        if(npcActual)
        {
            // comprobar si ha llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                Debug.Log("Hola!");
                npcActual = null;
                agent.stoppingDistance = 0;
            }
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
                // mirar a ver si el punto dnd he impactado en el raton tiene el script npc
                if (hit.transform.TryGetComponent(out Npc npc))
                {
                    // y en ese caso ese npc es el actual
                    npcActual = npc;
                    //ahora mi distancia de parada es la de interaccion (pararme a X metros del npc)
                    agent.stoppingDistance = distanciaInteraccion;
                }

                agent.SetDestination(hit.point);
            }

        }
    }
}
