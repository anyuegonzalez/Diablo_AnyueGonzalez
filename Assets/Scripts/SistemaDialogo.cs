using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo trono;
    private void Awake()
    {
        // si el trono esta vacio
        if (trono == null)
        {
            // reclamo el trono y me lo quedo 
            trono = this;
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
