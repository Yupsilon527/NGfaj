using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
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

        /*fireInput.x = Input.GetAxis(command + " Horizontal Fire");
        fireInput.y = Input.GetAxis(command + " Vertical Fire");

        miscInput.x = Input.GetAxis(command + " Change Weapon");*/
    }
    public void CleanControls()
    {
        moveInput = Vector2.zero;
        fireInput = Vector2.zero;
        miscInput = Vector2.zero;
    }
}
