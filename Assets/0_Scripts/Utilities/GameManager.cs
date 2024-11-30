using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ToggleCursorState(false);
    }

    public void ToggleCursorState(bool status)
    {
        Cursor.visible = status;
        Cursor.lockState = status ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
