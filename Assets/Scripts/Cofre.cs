using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{

    private Outline outline;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    // cuando pasamos el raton por encima
    private void OnMouseEnter()
    {
        
        outline.enabled = true;
    }
    // cuando quitamos el raton por encima
    private void OnMouseExit()
    {
        outline.enabled= false;
    }
}
