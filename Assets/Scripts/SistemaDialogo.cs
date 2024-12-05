using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo trono; // varios candidatos, el primero que llega se lo encuentra vacio y dice y el trono pa quien? pa mi, me quedo como un rey, si viene otro tipo me mato porque soy un rey falso
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
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
