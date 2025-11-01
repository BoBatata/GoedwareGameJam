using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, layerMask);
        Collider closestObject = colliders[0];
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
