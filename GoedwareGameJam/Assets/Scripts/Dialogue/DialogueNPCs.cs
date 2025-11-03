using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueNPCs : DialogueObj
{
    private BaseAI baseAi;
    [SerializeField] private string[] correctRoom;
    [SerializeField] private string[] wrongRoom;
    [SerializeField] private string[] unsureAnswer;
    [SerializeField] private string[] innocentAnswer;
    
    protected override void Awake()
    {
        base.Awake();
        baseAi = GetComponent<BaseAI>();
    }

    private void Start()
    {
        correctRoom = new string[2];
        wrongRoom = new string[2];
        unsureAnswer = new string[2];
        RandomCorrectAndWrongRoom();
    }

    public override void Interact(bool isInteract)
    {
        if (GameManager.Instance.huntTime) return;
        
        if (isInteract && !_hasInteracted)
        {
            if (baseAi._bef.isInfected)
            {
                GameManager.Instance.dialogueManager.StartDialogue(wrongRoom);
            }
            else if (!baseAi._bef.isInfected)
            {
                GameManager.Instance.dialogueManager.StartDialogue(innocentAnswer);
            }
            baseAi._bef.isInteracting = true;
            _hasInteracted =  true;
        }

        if (!isInteract)
        {
            baseAi._bef.isInteracting = false;
            _hasInteracted = false;
        }
    }

    public void RandomCorrectAndWrongRoom()
    {
        int correctIndex = Random.Range(0, GameManager.Instance.spotsWithKeys.Count - 1);
        correctRoom[0] = "The key? I think i saw it on the...";
        correctRoom[1] =  GameManager.Instance.spotsWithKeys[correctIndex].localName;
        
        int incorrectIndex = Random.Range(0, GameManager.Instance.spotsWithoutKeys.Count - 1);
        wrongRoom[0] = "The key? I think i saw it on the...";
        wrongRoom[1] =  GameManager.Instance.spotsWithoutKeys[incorrectIndex].localName;
        
        unsureAnswer[0] = "The key?";
        unsureAnswer[1] = "I don't think i saw it....";
        
        int innocentIndex = Random.Range(0, 1);
        if (innocentIndex == 0)
        {
            innocentAnswer = correctRoom;
        }
        else if (innocentIndex == 1)
        {
            innocentAnswer = unsureAnswer;
        }
    }
}
