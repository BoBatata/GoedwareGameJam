using UnityEngine;

public class DialogueNPCs : DialogueObj
{
    private BaseAI baseAi;
    private string correctRoom;
    private string wrongRoom;
    
    protected override void Awake()
    {
        base.Awake();
        baseAi = GetComponent<BaseAI>();
    }

    public override void Interact(bool isInteract)
    {
        if (baseAi._bef.isInfectedHuntTime) return;
        
        if (isInteract && !_hasInteracted)
        {
            GameManager.Instance.dialogueManager.StartDialogue(dialogues);
            baseAi._bef.isInteracting = true;
            _hasInteracted =  true;
        }

        if (!isInteract)
        {
            baseAi._bef.isInteracting = false;
            _hasInteracted = false;
        }
    }
}
