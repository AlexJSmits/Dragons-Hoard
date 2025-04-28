using Unity.VisualScripting;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D mouseOpen;
    public Texture2D mouseClosed;

    void Start()
    {
        Cursor.SetCursor(mouseOpen, new Vector2 (20, 20), CursorMode.ForceSoftware);
    }

    public void ForceHandOpen()
    {
        Cursor.SetCursor(mouseOpen, new Vector2 (20, 20), CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            Cursor.SetCursor(mouseClosed, new Vector2 (20, 20), CursorMode.ForceSoftware);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(mouseOpen, new Vector2 (20, 20), CursorMode.ForceSoftware);
        }
    }
}
