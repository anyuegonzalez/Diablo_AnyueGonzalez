using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField] private TMP_Text textoMision; // recipiente donde meter los textos de cada mision

    private Toggle toggle; // la cajita con el check

    public TMP_Text TextoMision { get => textoMision; set => textoMision = value; }
    public Toggle Toggle { get => toggle; set => toggle = value; }

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
}
