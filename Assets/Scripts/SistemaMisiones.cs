using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private ToggleMision[] toggleMision;

    private void OnEnable() 
    {
        eventManager.OnNuevaMision += ActivarToggleMision; // te suscribes al evento porque me interesa para enterarme de que hay una nueva mision
        eventManager.OnActualizarMision += ActualizarToggle;
        eventManager.OnTerminarMision += CerrarToggle;
    }

    private void ActualizarToggle(MisionSO mision)
    {
        // actualizar texto de la mision correspondiente
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
    }
    private void CerrarToggle(MisionSO mision)
    {
        toggleMision[mision.indiceMision].Toggle.isOn = true;
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;

        Destroy(toggleMision[mision.indiceMision].gameObject);

        // Eliminar la referencia de la lista
        toggleMision[mision.indiceMision] = null;
    }
    private void ActivarToggleMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        if(mision.repetir)
        {
            toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
        }

        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
}