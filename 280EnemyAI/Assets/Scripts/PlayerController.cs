using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody rb = null;
    public float moveSpeed = 10f;

    private void Awake()
    {
        input = new PlayerInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPreformed;
        input.Player.Movement.canceled += OnMovementCancelled;
     
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPreformed;
        input.Player.Movement.canceled -= OnMovementCancelled;

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
       
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

}
