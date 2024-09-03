using UnityEngine;
using TMPro;
using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private SoundID textSFX;
    [Space(10)]
    [SerializeField] private GameEvent OnDialogue;
    private Queue<string> sentences;
    private bool isDialogueActive;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (isDialogueActive) return;
        isDialogueActive = true;

        sentences.Clear();
        OnDialogue?.Raise();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if (!isDialogueActive) return;

        if (sentences.Count == 0)
        {
            EndDialogue();
            OnDialogue?.Raise();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            BroAudio.Play(textSFX);
            yield return null;
        }
    }

    private void EndDialogue() 
    {
        ToggleDialogueBox(false);
        isDialogueActive = false;
    }

    public void ToggleDialogueBox(bool value)
    {
        dialogueBox.gameObject.SetActive(value);
    }
}
