using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam= Camera.main; 
    }
    void Update()
    {
        // para que la barra pueda mirar a camara(solo funciona con camara ortografica)
        transform.forward = -cam.transform.forward;

    }
}
