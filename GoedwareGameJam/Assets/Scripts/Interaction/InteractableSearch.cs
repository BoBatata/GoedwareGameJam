using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractableSearch : InteractableBase
{
    [SerializeField] private int searchLevel;
    [SerializeField] private int currentSearchLevel;
    [SerializeField] private float timeToSearch;
    [SerializeField] private float timeLapsed;
    [SerializeField] public bool _doHaveKey;
    [SerializeField] private Slider sliderKey;
    private bool _alreadySearched;
    private bool _interacting;

    private void Start()
    {
        sliderKey.maxValue = searchLevel;
    }

    public override void Interact(bool isInteract)
    {
        if(_alreadySearched)  return;
        
        if (currentSearchLevel == searchLevel)
        {
            if (_doHaveKey)
            {
                GameManager.Instance.EarnKey(1);
                sliderKey.enabled = false;
                _alreadySearched = true;
            }
            else if (!_doHaveKey)
            {
                Debug.Log("Não tem nada aqui");
                sliderKey.enabled = false;
                _alreadySearched = true;
            }
            
        }

        if (_interacting)
        {
            GameManager.Instance.player.playerInteraction.isPlayerInteracting = true;
        }
        else
        {
            GameManager.Instance.player.playerInteraction.isPlayerInteracting = false;
        }
        
        if (isInteract)
        {
            _interacting = true;
            timeLapsed += Time.deltaTime;

            if (timeLapsed >= timeToSearch)
            {
                Debug.Log("✅ Interação completada segurando!");
                currentSearchLevel += 1;
                sliderKey.value = currentSearchLevel;
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
