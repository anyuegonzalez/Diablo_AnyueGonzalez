using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{

   [SerializeField] private Player player;
    private Vector3 distanciaAPlayer;
    void Start()
    {
        // miro la distanncia original que se tiene en escena
        distanciaAPlayer = transform.position - player.transform.position;
    }
    void Update()
    {
        // mi posicion en todos los frames es la del player + cierta distancia
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
