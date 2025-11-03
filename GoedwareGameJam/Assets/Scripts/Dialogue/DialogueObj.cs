using UnityEngine;

public class DialogueObj : InteractableOnce
{
    [SerializeField] protected string[] dialogues;
    
    public override void Interact(bool isInteract)
    {
        // if (isInteract && !_hasInteracted)
        // {
        //     GameManager.Instance.dialogueManager.StartDialogue(dialogues);
        //     _hasInteracted =  true;
        // }
        //
        // if (!isInteract)
        // {
        //     _hasInteracted = false;
        // }
    }
}
