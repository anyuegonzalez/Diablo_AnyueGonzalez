using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; // recoge...
    public string ordenFinal; // vuelve a hablar con...

    public bool repetir; // si la mision tiene varios pasos.
    public int repeticionesTotales; //total de veces de lo que tenemos que hacer

    [NonSerialized]public int estadoActual = 0; //para que la variable se pueda resetear la variable. variable que nos marca donde estamos o cuantas llevamos 
    

    public int indiceMision;
}
