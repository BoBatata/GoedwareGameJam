using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    public InputController inputController;
    
    public Vector2 MoveDir => inputController.Player.Walk.ReadValue<Vector2>();
    public bool interactHolding;

    public InputManager(){
        inputController = new InputController();
        EnableInput();
        
        inputController.Player.Interact.performed += OnInteract;
        inputController.Player.Interact.canceled += OnInteract;
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactHolding = true;
        }

        if (context.canceled)
        {
            interactHolding = false;
        }
    }
    
    public void EnableInput() => inputController.Enable();
    public void DisableInput() => inputController.Disable();
}
