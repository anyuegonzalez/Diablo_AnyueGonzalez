using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaSalida : MonoBehaviour
{
    [SerializeField] private string nombreEscena; // Nombre de la escena a cargar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al trigger es el jugador
        if (other.CompareTag("Player"))
        {
           
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(nombreEscena); // Carga la escena especificada
    }
}
