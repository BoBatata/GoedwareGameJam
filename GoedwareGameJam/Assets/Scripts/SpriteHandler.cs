using System;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    private void LateUpdate()
    {
        if (Camera.main == null) return;
        
        transform.LookAt(Camera.main.transform);

        // Corrige rotação para manter o sprite de frente (caso fique invertido)
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180f, 0);

        Vector3 cameraDirection = Camera.main.transform.position - transform.position;
        cameraDirection.y = 0; // Mantém no eixo horizontal (opcional)
        transform.rotation = Quaternion.LookRotation(-cameraDirection);
    }
}
