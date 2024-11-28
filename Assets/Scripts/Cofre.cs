using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{

    private Outline outline;

    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }


    // cuando pasamos el raton por encima
    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    // cuando quitamos el raton por encima
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled= false;
    }
}
