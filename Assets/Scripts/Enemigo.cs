using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    List<Transform> listadoPuntos = new List<Transform>(); 
    void Start()
    {
        // voy recorriendo todos los puntos que tine mi ruta
       foreach (Transform punto in ruta)
       {
            // y los añado en mi lista
           listadoPuntos.Add(punto);
       }
    }
    void Update()
    {
        
    }
}
