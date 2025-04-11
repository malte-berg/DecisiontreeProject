using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
        FindFirstObjectByType<DialogueManager>().Init();
        TriggerDialogue();
    }

    public void TriggerDialogue () {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}
