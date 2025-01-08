using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    private void Awake()
    {
        main.Combate = this;
    }
    void Start()
    {
       
    }
    void Update()
    {
        
    }
}
