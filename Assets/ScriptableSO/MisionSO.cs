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
    public int estadoActual; // variable que nos marca donde estamos o cuantas llevamos 

    public int indiceMision;
}
