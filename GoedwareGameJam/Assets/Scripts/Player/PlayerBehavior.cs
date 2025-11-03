using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
    public enum State{
        Idle,
        Walk,
        Run
    }
    
    public InputManager inputManager;
    private PlayerMovement _playerMovement;
    public PlayerInteraction playerInteraction;

    [SerializeField] public bool canBeInSight = true;

    private void Awake()
    {
        inputManager = new InputManager();
        _playerMovement = GetComponent<PlayerMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void Update()
    {
        if (GameManager.Instance.dialogueManager.IsDialogueActive)
        {
            GameManager.Instance.dialogueManager.TryAdvanceDialogue(inputManager.nextDialogue);
            return;
        }
        
        _playerMovement.WalkHandler(inputManager.MoveDir);
        playerInteraction.InteractHandler(inputManager.interact);
    }
}
