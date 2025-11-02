using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Managers")]
    public DialogueManager dialogueManager;

    [Header("Game Status")] 
    [SerializeField] private int keysToWin;
    [SerializeField] private int currentKeys;

    [SerializeField] private InteractableSearch[] searchSpots;
    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        RandomSpotsWithKeys(3);
    }

    private void Update()
    {
        if (currentKeys >= keysToWin)
        {
            Debug.Log("Ganhou!");
        }
    }

    private void RandomSpotsWithKeys(int amount)
    {
        InteractableSearch[] spotsWithKeys = SelectRandom(searchSpots, amount);

        foreach (var spot in spotsWithKeys)
        {
            spot._doHaveKey = true;
        }
    }
    
    public static T[] SelectRandom<T>(T[] originalArray, int amount)
    {
        // Garante que a quantidade não ultrapasse o tamanho do array
        if (amount > originalArray.Length)
        {
            Debug.LogWarning("Quantidade maior que o tamanho do array. Ajustando para valor máximo.");
            amount = originalArray.Length;
        }

        // Cria uma cópia do array original para embaralhar
        T[] copia = new T[originalArray.Length];
        for (int i = 0; i < originalArray.Length; i++)
        {
            copia[i] = originalArray[i];
        }

        // Embaralhamento Fisher-Yates no array copiado
        for (int i = 0; i < copia.Length; i++)
        {
            int indiceAleatorio = Random.Range(i, copia.Length);
            // Troca de posição
            T temp = copia[i];
            copia[i] = copia[indiceAleatorio];
            copia[indiceAleatorio] = temp;
        }

        // Cria um novo array com a quantidade desejada
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
