using UnityEngine;

public class InteractableSearch : InteractableBase
{
    [SerializeField] private int searchLevel;
    [SerializeField] private float timeToSearch;
    [SerializeField] private float timeLapsed;
    private bool _interacting;

    public override void Interact(bool isInteract)
    {
        if (isInteract)
        {
            _interacting = true;
            timeLapsed += Time.deltaTime;

            if (timeLapsed >= timeToSearch)
            {
                Debug.Log("✅ Interação completada segurando!");
                searchLevel += 1;
                timeLapsed = 0;
                _interacting = false;
            }
        }
        else
        {
            // Soltou antes de completar
            if (_interacting)
            {
                Debug.Log("❌ Soltou antes de completar!");
                _interacting = false;
                timeLapsed = 0f;
            }
        }
    }

    // public void SearchHandler()
    // {
    //     if (isBeingInteracted)
    //     {
    //         timeLapsed += Time.deltaTime;
    //
    //         if (timeLapsed >= timeToSearch)
    //         {
    //             searchLevel += 1;
    //             timeLapsed = 0;
    //         }
    //     }
    //     else if (!isBeingInteracted)
    //     {
    //         timeLapsed = 0;
    //     }
    // }
}
