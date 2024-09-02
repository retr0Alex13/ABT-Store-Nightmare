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
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentance();
    }

    [ContextMenu("DisplayNextSentance")]
    public void DisplayNextSentance()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
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
    }

    public void ToggleDialogueBox(bool value)
    {
        dialogueBox.gameObject.SetActive(value);
    }
}
