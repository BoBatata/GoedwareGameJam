using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputController inputController;

    public Vector2 MoveDir => inputController.Player.Walk.ReadValue<Vector2>();

    public InputManager(){
        inputController = new InputController();
        EnableInput();
    }


    public void EnableInput() => inputController.Enable();
    public void DisableInput() => inputController.Disable();
}
