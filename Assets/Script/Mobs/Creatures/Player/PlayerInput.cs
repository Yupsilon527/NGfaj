using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : PlayerComponent
{
    void Update()
    {
        HandleControls();
    }

    public Vector2 moveInput;
    public Vector2 fireInput;
    public Vector2 miscInput;
    public void HandleControls()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Cancel"))
        {
            parent.menu.ShutDownMenu();
        }
    }
    public void CleanControls()
    {
        moveInput = Vector2.zero;
        fireInput = Vector2.zero;
        miscInput = Vector2.zero;
    }
}
