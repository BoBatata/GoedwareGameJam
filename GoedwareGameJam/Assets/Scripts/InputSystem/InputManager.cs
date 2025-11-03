using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    public InputController inputController;
    
    public Vector2 MoveDir => inputController.Player.Walk.ReadValue<Vector2>();
    public bool interact;
    public bool nextDialogue;

    public InputManager(){
        inputController = new InputController();
        EnableInput();
        
        inputController.Player.Interact.performed += OnInteract;
        inputController.Player.Interact.canceled += OnInteract;
        
        
        inputController.Player.Dialogue.performed += OnNextDialogue;
        inputController.Player.Dialogue.canceled  += OnNextDialogue;
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        interact = context.performed;
    }
    
    private void OnNextDialogue(InputAction.CallbackContext context)
    {
        nextDialogue = context.performed;
    }
    
    public void EnableInput() => inputController.Enable();
    public void DisableInput() => inputController.Disable();
    
    public void EnableInputWalk() => inputController.Player.Walk.Enable();
    public void DisableInputWalk() => inputController.Player.Walk.Disable();
}
