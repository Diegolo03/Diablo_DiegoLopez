using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Cofre : MonoBehaviour
{

    private Outline outline;
    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnMouseEnter()
    {
        
        Cursor.SetCursor(cursorInteraccion, Vector2.zero,CursorMode.Auto);
        outline.enabled = true;
        
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
}
