using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    void Start()
    {
       foreach (Transform punto in ruta)
       {
            Debug.Log(punto.name);
       }
    }
    void Update()
    {
        
    }
}
