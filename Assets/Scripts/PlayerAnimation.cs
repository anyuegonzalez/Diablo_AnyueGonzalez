using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void EjecutarAtaque()
    {
        anim.SetBool("attaking", true);
    }
    public void PararAtaque()
    {
        anim.SetBool("attaking", false);
    }
}
