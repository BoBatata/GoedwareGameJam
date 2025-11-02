using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask layerMask;

    private Collider closestObject;

    private void Update()
    {
        CloseInteractableObj();
    }

    public void InteractHandler(bool isInteracting)
    {
        if(closestObject == null) return;
        if (closestObject.TryGetComponent(out InteractableBase interactable))
        {
            interactable.Interact(isInteracting);
        }
    }

    private void CloseInteractableObj()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, layerMask);
        if (colliders.Length == 0) return;
        closestObject = colliders[0];
        float distanceToClosest = Vector3.Distance(transform.position, closestObject.transform.position);
        Debug.DrawLine(transform.position, closestObject.transform.position, Color.red);
        
        if (closestObject.TryGetComponent(out InteractableBase interactable))
        {
            interactable.CloseCheck();
        }
        
        for (int i = 1; i < colliders.Length; i++)
        {
            float distanceToCurrent = Vector3.Distance(transform.position, colliders[i].transform.position);

            if (distanceToCurrent < distanceToClosest)
            {
                closestObject = colliders[i];
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
