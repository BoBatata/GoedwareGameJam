using UnityEngine;

public class DialogueNPCs : DialogueObj
{
    private BaseAI baseAi;
    protected override void Awake()
    {
        base.Awake();
        baseAi = GetComponent<BaseAI>();
    }

    public override void Interact(bool isInteract)
    {
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
