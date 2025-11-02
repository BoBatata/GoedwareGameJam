using UnityEngine;

public class InteractableHidden : InteractableOnce
{
    public override void Interact(bool isInteract)
    {
        if (isInteract && !_hasInteracted)
        {
            GameManager.Instance.player.canBeInSight = false;
            GameManager.Instance.player.inputManager.DisableInputWalk();
            _hasInteracted =  true;
        }

        if (!isInteract)
        {
            _hasInteracted = false;
        }
    }
}
