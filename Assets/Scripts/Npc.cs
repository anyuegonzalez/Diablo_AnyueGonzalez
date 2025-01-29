using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Npc : MonoBehaviour, IInteractuable
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MisionSO misionAsociada;

    private Outline outline;
    [SerializeField] private float tiempoRotacion;

    [SerializeField] private DialogaSO dialogo;
    [SerializeField] private DialogaSO dialogo2;

    private DialogaSO dialogoActual;

    [SerializeField] private Transform puntoCamara;
    private void Awake()
    {
        dialogoActual = dialogo;
        outline = GetComponent<Outline>();
    }
    // para que el npc se gire hacia el que le esta interactuando (jugador)
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogo.trono.IniciarDialogo(dialogoActual, puntoCamara));
    }
    private void OnEnable()
    {
        // me suscribo al evento para esatr atento de cuando cambiar dialogo
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
       if(misionTerminada == misionAsociada)
       {
            dialogoActual = dialogo2;
       }
    }

    private void OnMouseEnter()
    {  
        outline.enabled = true;
    }
    // cuando quitamos el raton por encima
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
