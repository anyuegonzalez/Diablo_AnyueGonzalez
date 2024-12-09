using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo trono; // varios candidatos, el primero que llega se lo encuentra vacio y dice y el trono pa quien? pa mi, me quedo como un rey, si viene otro tipo me mato porque soy un rey falso

    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private DialogaSO dialogoActual; // para almacenar con que dialogo estamos trabajando

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
        // el dialogo actual con el que trabajamos es el que me dan por parametro de entrada
        dialogoActual = dialogo;
        marcos.SetActive(true);
        StartCoroutine(EscribirFrase());
    }
    // que el texto aparezca letra a letra
    private IEnumerator EscribirFrase()
    {
        // limpio el texto antes de poner una nueva frase 
        textoDialogo.text = "";
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray(); // convierte la frase pero en un array de caracteres
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(dialogoActual.tiempoEntreLetras);
        }

    }
    public void SiguienteFrase()
    {

    }
    private void TerminarDialogo()
    { 
    
    }
   
}
