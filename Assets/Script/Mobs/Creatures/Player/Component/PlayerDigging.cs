using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDigging : PlayerComponent
{
    void Update()
    {
        if (Input.GetButtonDown("Dig") && parent.backpack.GetActiveItem() == null)
        {
            if (DiggingCoroutine==null && parent.IsGrounded())
            {
                StartCoroutine(DiggingTask());
            }
            
        }
    }
    Coroutine DiggingCoroutine;
    Vector2 digVector = Vector2.zero;
    float lastDigTime = 0;
    IEnumerator DiggingTask()
    {
        parent.CanMove = false;
        while (Input.GetButton("Dig"))
        {
            DigDirection();
            parent.gravity.relativeForce = parent.WalkSpeed * digVector * parent.MoveSpeedMultiplier;
            yield return new WaitForEndOfFrame();
        }
        StopDigging();
    }
    void DigDirection()
    {
        digVector = parent.input.moveInput;
        digVector = digVector.y * transform.up + digVector.x * transform.right;
        if (digVector.sqrMagnitude > 0 && lastDigTime < Time.time)
        {
            lastDigTime = Time.time + parent.GetDigTime();
            new ExplosionData((Vector2)transform.position + digVector * parent.DigRange, parent.DigRadius, 0, 0, parent.GetDigDamage(), 0).Explode();
            
        }
    }
    public void StopDigging()
    {
        if (DiggingCoroutine != null)
            StopCoroutine(DiggingCoroutine);
        DiggingCoroutine = null;
        parent.CanMove = true;
    }
    private void OnDisable()
    {
        StopDigging();
    }
}
