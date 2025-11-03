using UnityEngine;

public class InteractableHidden : InteractableOnce
{
    private bool _isHidden = false;
    private bool _canToggle = true;

    public override void Interact(bool isInteract)
    {
        if (isInteract && _canToggle)
        {
            _isHidden = !_isHidden;

            if (_isHidden)
            {
                GameManager.Instance.player.playerInteraction.isCloesestObjectLocked = true;
                GameManager.Instance.player.playerInteraction._closestObject = GetComponent<Collider>();
                GameManager.Instance.player.spriteHandler.spriteRenderer.enabled = false;
                GameManager.Instance.player.canBeInSight = false;
                GameManager.Instance.player.inputManager.DisableInputWalk();
            }
            else
            {
                GameManager.Instance.player.playerInteraction.isCloesestObjectLocked = false;
                GameManager.Instance.player.spriteHandler.spriteRenderer.enabled = true;
                GameManager.Instance.player.canBeInSight = true;
                GameManager.Instance.player.inputManager.EnableInputWalk();
            }
            
            _canToggle = false;
        }
        
        if (!isInteract)
        {
            _canToggle = true;
        }
    }
}
