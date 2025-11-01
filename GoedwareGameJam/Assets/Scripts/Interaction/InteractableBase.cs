using System;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void CloseCheck()
    {
        print("Perto para interagir!");
        renderer.material.color = Color.red;
    }
}
