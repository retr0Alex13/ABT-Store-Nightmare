using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    private bool isTriggered;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered) { return; }
        TriggerDialogue();
        dialogueManager.ToggleDialogueBox(true);
        isTriggered = true;
    }
}
