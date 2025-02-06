using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{

    private Transform mainTarget;
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    [SerializeField]
    private GameObject localCanvas;

    //[SerializeField]
    //private Collider coll;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => mainTarget; }
    public EnemyVisualSystem1 VisualSystem { get => visualSystem; set => visualSystem = value; }

    private float vidasActuales;
    private bool muerto;
    [SerializeField]
    private Image healthBar;

    private EnemyVisualSystem1 visualSystem;

    [SerializeField]
    private float vidasIniciales;

    private void Start()
    {
        // empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }
    public void RecibirDanho(float danho)
    {
        if (muerto) return;

        vidasActuales -= danho;
        healthBar.fillAmount = vidasActuales / vidasIniciales;
        if (vidasActuales <= 0)
        {
            muerto = true;
            Muerte();
        }
    }
    private void Muerte()
    {

        Destroy(localCanvas.gameObject);
        //Destroy(coll);
        Destroy(combate);
        Destroy(patrulla.gameObject);
        Destroy(gameObject, 5);
        visualSystem.EjecutarAnimacionMuerte();
    }

    public void ActivaCombate(Transform target)
    {
        // ahora tenemos un target al cual perseguir 
        mainTarget = target;

        // aqui nos dicen de activar el combate
        combate.enabled = true;
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;
    }
}    

