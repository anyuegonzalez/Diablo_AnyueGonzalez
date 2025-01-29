using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour
{
    private Outline outline;
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
