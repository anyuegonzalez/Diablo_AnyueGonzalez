using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractuable
{

    private Outline outline;

    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;

    public void Interactuar(Transform interactuador)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
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
