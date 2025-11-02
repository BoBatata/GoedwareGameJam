using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
    public enum State{
        Idle,
        Walk,
        Run
    }
    
    private InputManager _inputManager;
    private PlayerMovement _playerMovement;
    private PlayerInteraction _playerInteraction;

    private void Awake()
    {
        _inputManager = new InputManager();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void Update()
    {
        _playerMovement.WalkHandler(_inputManager.MoveDir);
        _playerInteraction.InteractHandler(_inputManager.interactHolding);
    }
}
