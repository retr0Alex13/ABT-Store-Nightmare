using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerByCollider;
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
        dialogueManager.ToggleDialogueBox(true);
        isTriggered = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerByCollider) 
        { 
            return; 
        }
        if (isTriggered) 
        { 
            return;
        }

        TriggerDialogue();
    }
}
