using UnityEngine;
using UnityEngine.Events;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerByCollider;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private UnityEvent unityEvent;

    private bool isTriggered;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.SetUnityEvent(unityEvent);
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
