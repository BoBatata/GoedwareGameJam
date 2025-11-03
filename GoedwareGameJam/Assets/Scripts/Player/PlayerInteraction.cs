using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask layerMask;
    public bool isPlayerInteracting;

    public Collider _closestObject;

    private void Update()
    {
        if (isPlayerInteracting) return;
        CloseInteractableObj();
    }

    public void InteractHandler(bool isInteracting)
    {
        if(_closestObject == null) return;
        if (_closestObject.TryGetComponent(out InteractableBase interactable))
        {
            interactable.Interact(isInteracting);
        }
    }

    private void CloseInteractableObj()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, layerMask);
        if (colliders.Length == 0) return;
        _closestObject = colliders[0];
        float distanceToClosest = Vector3.Distance(transform.position, _closestObject.transform.position);
        Debug.DrawLine(transform.position, _closestObject.transform.position, Color.red);
        
        if (_closestObject.TryGetComponent(out InteractableBase interactable))
        {
            interactable.CloseCheck();
        }
        
        for (int i = 1; i < colliders.Length; i++)
        {
            float distanceToCurrent = Vector3.Distance(transform.position, colliders[i].transform.position);

            if (distanceToCurrent < distanceToClosest)
            {
                _closestObject = colliders[i];
                distanceToClosest = distanceToCurrent;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.75f, 0.0f, 0.0f, 0.75f);
        
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
