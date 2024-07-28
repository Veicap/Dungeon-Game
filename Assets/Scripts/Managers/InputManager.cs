using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerInputActions playerInputActions;
    public event EventHandler OnJump;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        Instance = this;
    }
    private void Start()
    {
        playerInputActions.Player.Jump.Enable();
        playerInputActions.Player.Jump.performed += Jump_performed;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Jump.Enable();
        playerInputActions.Player.Jump.performed -= Jump_performed;
        playerInputActions.Dispose();
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJump?.Invoke(this, EventArgs.Empty);
    }
}
