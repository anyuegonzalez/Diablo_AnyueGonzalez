using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private NavMeshAgent agent;

    List<Vector3> listadoPuntos = new List<Vector3>();

    private Vector3 destinoActual; // marca el destino actual al cual tenemos que ir

    private int indiceRutaActual = -1; // marca el indice del nuevo punto al cual patrullar
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        // voy recorriendo todos los puntos que tine mi ruta
        foreach (Transform punto in ruta)
        {
            // y los añado en mi lista
            listadoPuntos.Add(punto.position);
        }
        CalcularDestino();
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        agent.SetDestination(destinoActual);
        yield return null;
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
