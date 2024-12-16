using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    [SerializeField] NavMeshAgent agent;

    List<Vector3> listadoPuntos = new List<Vector3>();

    private Vector3 destinoActual; // marca el destino actual al cual tenemos que ir

    private int indiceRutaActual = -1; // marca el indice del nuevo punto al cual patrullar
    private int tiempoEntrePuntos;

    private void Awake()
    {
        // voy recorriendo todos los puntos que tine mi ruta
        foreach (Transform punto in ruta)
        {
            // y los añado en mi lista
            listadoPuntos.Add(punto.position);
        }    
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true) // por siempre,,,
        {
            CalcularDestino(); // 1. calculas un nuvo destino 
            agent.SetDestination(destinoActual); // 2. se te marca dicho destino

            //3. esperas a llegar a dicho destino y repites
            yield return new WaitUntil( ()=> !agent.pathPending && agent.remainingDistance <= 0.2f); // espera hasta que llegues a ese punto
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));


        }
       
    }
    private void CalcularDestino()
    {
        indiceRutaActual++;
        //Count para las listas, es lo mismo que Length en los arrays
        if(indiceRutaActual >= listadoPuntos.Count)
        {
            // si no me quedan puntos, volvere a al punto 0
            indiceRutaActual = 0;
        }
        destinoActual = listadoPuntos[indiceRutaActual];
    }
}
