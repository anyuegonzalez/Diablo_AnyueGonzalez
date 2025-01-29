using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractuable
{

    [SerializeField] private EventManagerSO eventManager;
    private Outline outline;


    [SerializeField] private MisionSO misionAsociada;
    public void Interactuar(Transform interactuador)
    {
        eventManager.ActualizarMison(misionAsociada);
        Destroy(this.gameObject);
    }
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnMouseEnter()
    {
      outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
