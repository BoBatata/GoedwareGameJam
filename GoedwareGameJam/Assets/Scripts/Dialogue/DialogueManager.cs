using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI   textTMP;
    [SerializeField] private GameObject  dialogueBox;
    [SerializeField] private float typingSpeed = 0.03f;
    
    private string[] _currentDialogues;
    private int _currentIndex = 0;
    private bool _isTyping = false;
    private Coroutine _typingCoroutine;
    
    private bool canAdvance = true;
    
    public bool IsDialogueActive => dialogueBox.activeSelf;

    public void ActivateDialogueBox(bool isActive)
    {
        dialogueBox.SetActive(isActive);
        if (!isActive)
        {
            textTMP.text = "";
            _currentIndex = 0;
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        _currentDialogues = dialogues;
        ActivateDialogueBox(true);
        _currentIndex = 0;
        ShowNextDialogue();
    }

    public void EndDialogue()
    {
        ActivateDialogueBox(false);
    }
    
    public void ShowNextDialogue()
    {
        if (!IsDialogueActive) return;
        
        if (_isTyping)
        {
            textTMP.text = _currentDialogues[_currentIndex];
            _isTyping = false;
            StopCoroutine(_typingCoroutine);
            return;
        }

        if (_currentIndex < _currentDialogues.Length)
        {
            _typingCoroutine = StartCoroutine(TypeSentence(_currentDialogues[_currentIndex]));
            _currentIndex++;
        }
        else
        {
            EndDialogue();
        }
    }
    
    
    private IEnumerator TypeSentence(string sentence)
    {
        _isTyping = true;
        textTMP.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            textTMP.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        _isTyping = false;
    }
    
    public void TryAdvanceDialogue(bool nextDialoguePressed)
    {
        if (!nextDialoguePressed)
        {
            canAdvance = true;
        }

        if (nextDialoguePressed && canAdvance)
        {
            canAdvance = false;
            ShowNextDialogue();
        }
    }
}
