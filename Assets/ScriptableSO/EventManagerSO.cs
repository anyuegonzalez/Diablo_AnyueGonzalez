using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    // los metodos que empiezan por On se ejecutan por metodos, de forma automatica
    public event Action OnNuevaMision;
    public void NuevaMision()
    {
        // aqui lanzo la notificacion (el evento) por si a alguien le interesa
        OnNuevaMision.Invoke();
    }
}
