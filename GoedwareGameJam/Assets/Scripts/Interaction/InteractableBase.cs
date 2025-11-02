using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    protected Renderer _renderer;
    protected bool isBeingInteracted = false;

    protected virtual void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public virtual void Interact(bool isInteracting)
    {
        isBeingInteracted = isInteracting;
    }

    public virtual void CloseCheck()
    {
        print("Perto para interagir!");
        _renderer.material.color = Color.red;
    }
    
    
}
