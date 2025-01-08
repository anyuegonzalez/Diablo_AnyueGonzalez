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

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }

    private void Start()
    {
        // empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }

    public void ActivaCombate(Transform target)
    {
        // ahora tenemos un target al cual perseguir 
        mainTarget = target;

        // aqui nos dicen de activar el combate
        combate.enabled = true;
    }
}    

