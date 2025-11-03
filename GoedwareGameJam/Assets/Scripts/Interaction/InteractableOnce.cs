using UnityEngine;

public class InteractableOnce : InteractableBase
{
    protected bool _hasInteracted;
    
    public override void Interact(bool isInteract)
    {
        if (isInteract && !_hasInteracted)
        {
            Debug.Log("Interacting with " + this.name);
            _hasInteracted =  true;
        }

        if (!isInteract)
        {
            _hasInteracted = false;
        }
    }
}
