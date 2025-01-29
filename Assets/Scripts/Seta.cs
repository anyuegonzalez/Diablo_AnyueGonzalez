using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractuable
{
    private Outline outline;

    public void Interactuar(Transform interactuador)
    {
        
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
