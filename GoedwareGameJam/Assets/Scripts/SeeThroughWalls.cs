using UnityEngine;
using UnityEngine.Rendering;

public class SeeThroughWalls : MonoBehaviour
{
    [Header("Referências")]
    public Transform target;
    public LayerMask obstructionMask;
    
    private Transform currentObstruction;

    private void LateUpdate()
    {
        HandleObstruction();
    }

    void HandleObstruction()
    {
        if (currentObstruction != null)
        {
            RestoreObstruction(currentObstruction);
            currentObstruction = null;
        }
        
        if (Physics.Raycast(transform.position, target.position - transform.position, out RaycastHit hit, Vector3.Distance(target.position, transform.position), obstructionMask))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                currentObstruction = hit.transform;
                MakeTransparent(currentObstruction);
            }
        }
    }

    void MakeTransparent(Transform obj)
    {
        foreach (Transform child in obj.parent)
        {
            var renderer = child.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
            }
        }
    }

    void RestoreObstruction(Transform obj)
    {
        foreach (Transform child in obj.parent)
        {
            var renderer = child.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.shadowCastingMode = ShadowCastingMode.On;
            }
        }
    }
}
