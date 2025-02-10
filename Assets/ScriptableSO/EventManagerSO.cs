using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    // los metodos que empiezan por On se ejecutan por metodos, de forma automatica
    public event Action<MisionSO> OnNuevaMision; // evento 

    public event Action<float, float> OnPlayerStartsInspecting;
    public event Action<float> OnPlayerStopsInspecting;

    public event Action<float, float> OnInspecting; // Se activa cuando el jugador comienza a inspeccionar
    public event Action<float> OnStopInspecting; // Se activa cuando el jugador deja de inspeccionar

    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;
    public void NuevaMision(MisionSO mision)
    {
        // aqui lanzo la notificacion (el evento) por si a alguien le interesa
        
        // ?. : invocacion segura. se asegura de que haya suscriptores
        // si no hay invocacion segura el juego peta
        OnNuevaMision?.Invoke(mision);
    }
    public void ActualizarMison(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }
    public void TerminarMision(MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }
    public void PlayerStopsInspecting(float quitInspectionDuration)
    {
        // Dispara el evento notificando a los sistemas suscritos
        OnPlayerStopsInspecting?.Invoke(quitInspectionDuration);
    }

    public void PlayerStartsInspecting(float startInspectionDuration, float distanceToLookPoint)
    {
        // Dispara el evento notificando a los sistemas suscritos
        OnPlayerStartsInspecting?.Invoke(startInspectionDuration, distanceToLookPoint);
    }  

}
