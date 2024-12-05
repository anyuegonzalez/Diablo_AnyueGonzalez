using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo trono; // varios candidatos, el primero que llega se lo encuentra vacio y dice y el trono pa quien? pa mi, me quedo como un rey, si viene otro tipo me mato porque soy un rey falso

    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo; // determina si el sistema esta escribiendo o no 
    private int indiceFraseActual; // marca la frase por la que voy 
    private void Awake()
    {
        // si el trono esta vacio
        if (trono == null)
        {
            // reclamo el trono y me lo quedo 
            trono = this;

            // y no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void IniciarDialogo(DialogaSO dialogo)
    {
        marcos.SetActive(true);  
    }
    // que el texto aparezca letra a letra
    private void EscribirFrase()
    {

    }
    private void SiguienteFrase()
    {

    }
    private void TerminarDialogo()
    { 
    
    }
   
}
