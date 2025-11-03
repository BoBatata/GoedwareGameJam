using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public PlayerBehavior player;
    
    [Header("Managers")]
    public DialogueManager dialogueManager;
    public AiManager aiManager;
    public UIManager uiManager;
    public SoundManager soundManager;

    [Header("Game Status")] 
    [SerializeField] private int keysToWin;
    [SerializeField] private int currentKeys;

    [SerializeField] private InteractableSearch[] searchSpots;

    [Header("Hunt Timer")] 
    [SerializeField] private float remainingTime;
    [SerializeField] private float currentRemainingTime = 60f;
    [SerializeField] public bool huntTime = false;

    [Header("Rooms")] 
    [SerializeField] public List<InteractableSearch> spotsWithKeys;
    [SerializeField] public List<InteractableSearch> spotsWithoutKeys;
    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        player = FindObjectOfType<PlayerBehavior>();

        RandomSpotsWithKeys(3);
        soundManager.PlaySound(1);
    }

    private void Update()
    {
        TimerHandler();
        uiManager.UpdateKeyUI(currentKeys);
        
        if (currentKeys >= keysToWin)
        {
            Debug.Log("Ganhou!");
            EndGame();
            uiManager.EndPanel(true, "You Escaped!");
            soundManager.StopSound();
        }
    }

    public void EndGame()
    {
        foreach (var npc in aiManager.npcs)
        {
            npc.gameObject.SetActive(false);
        }
        
        player.inputManager.DisableInput();
    }

    private void TimerHandler()
    {
        currentRemainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentRemainingTime / 60);
        int seconds = Mathf.FloorToInt(currentRemainingTime % 60);
        uiManager.UpdateTimer(minutes, seconds);

        if (currentRemainingTime <= 0 && !huntTime)
        {
            aiManager.ActivateInfectedHunt(true);
            huntTime = true;
            currentRemainingTime = remainingTime;
            soundManager.PlaySound(0);
        }
        else if (currentRemainingTime <= 0 && huntTime)
        {
            aiManager.ActivateInfectedHunt(false);
            huntTime = false;
            currentRemainingTime = remainingTime - 10;
            soundManager.PlaySound(1);
        }
    }

    private void RandomSpotsWithKeys(int amount)
    {
        foreach (var spot in SelectRandom(searchSpots, amount))
        {
            spotsWithKeys.Add(spot);
        }

        foreach (var spot in spotsWithKeys)
        {
            spot._doHaveKey = true;
        }

        foreach (var spot in searchSpots)
        {
            if (spot._doHaveKey == false)
            {
                spotsWithoutKeys.Add(spot);
            }
                
        }
        
        // foreach (var npc in aiManager.npcs)
        // {
        //     npc.GetComponent<DialogueNPCs>().RandomCorrectAndWrongRoom();
        // }
    }
    
    public T[] SelectRandom<T>(T[] originalArray, int amount)
    {
        if (amount > originalArray.Length)
        {
            amount = originalArray.Length;
        }
        
        T[] copia = new T[originalArray.Length];
        for (int i = 0; i < originalArray.Length; i++)
        {
            copia[i] = originalArray[i];
        }
        
        for (int i = 0; i < copia.Length; i++)
        {
            int indiceAleatorio = Random.Range(i, copia.Length);
            T temp = copia[i];
            copia[i] = copia[indiceAleatorio];
            copia[indiceAleatorio] = temp;
        }
        
        T[] resultado = new T[amount];
        for (int i = 0; i < amount; i++)
        {
            resultado[i] = copia[i];
        }

        return resultado;
    }
    public void EarnKey(int amount)
    {
        currentKeys += amount;
    }
}
