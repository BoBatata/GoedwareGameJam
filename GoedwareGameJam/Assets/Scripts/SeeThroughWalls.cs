using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SeeThroughWalls : MonoBehaviour
{
    public Transform target;

    public Transform obstruction;
    float zoomSpeed = 2f;

    private void LateUpdate()
    {
        ViewObstructed();
    }

    void ViewObstructed()
    {
        if (obstruction != null)
        {
            foreach (Transform child in obstruction.parent)
            {
                child.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, target.position - transform.position, out hit))
        {
            Debug.DrawRay(transform.position, target.position - transform.position, Color.green);

            if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "Ground")
            {
                print(hit.collider.gameObject.name);

                obstruction = hit.transform;
                //obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                //obstruction.parent.GetComponentInChildren<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                foreach (Transform child in obstruction.parent)
                {
                    child.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                }

                if (Vector3.Distance(obstruction.position, transform.position) >= 10f && Vector3.Distance(transform.position, target.position) >= 7f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

            if (Vector3.Distance(transform.position, target.position) < 4.5f)
            {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }
}
