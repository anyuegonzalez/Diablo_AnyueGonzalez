using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private GameObject toggleMision;

    private void OnEnable() 
    {
        eventManager.OnNuevaMision += ActivarToggleMision; // te suscribes al evento porque me interesa para enterarme de que hay una nueva mision
    }

    private void ActivarToggleMision()
    {
       toggleMision.SetActive(true);
    }
}