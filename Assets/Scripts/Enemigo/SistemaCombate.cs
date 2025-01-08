using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    void Start()
    {
        main.Combate = this;
    }
    void Update()
    {
        
    }
}
