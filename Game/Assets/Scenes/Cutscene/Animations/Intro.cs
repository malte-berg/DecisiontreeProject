using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro : SceneScript {
    public GameObject dialogueBox;
    public GameObject mainStoryTrigger;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;

    public override IEnumerator RunAnimation() {
        //Add dialogue box to scene inside of "Canvas" object.
        dialogueBox = Instantiate(dialogueBox, GameObject.FindGameObjectWithTag("Canvas").transform);

        //Get name and dialogue text components.
        nameText = dialogueBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        //Set some public attributes of the dialogue manager.
        DialogueManager dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
        dialogueManager.nameText = nameText;
        dialogueManager.dialogueText = dialogueText;

        //Start main story dialogue.
        mainStoryTrigger = Instantiate(mainStoryTrigger);

        //Set dialogue box "continue" button to the correct onClick functionality
        dialogueBox.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => dialogueManager.DisplayNextSentence());

        while(dialogueManager.dialogueActive){
            yield return null;
        }
    }

}