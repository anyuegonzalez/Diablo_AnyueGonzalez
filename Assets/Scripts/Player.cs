using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
   
    private NavMeshAgent agent;
    private Camera cam;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;

    }
    void Update()
    {
        // trazar un raycast desde la camara a la posicion del raton
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
              agent.SetDestination(hit.point);
            }
            
        }
    }
}