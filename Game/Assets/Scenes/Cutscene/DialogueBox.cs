using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour{

    SceneScript sc;
    List<string> queue = new List<string>();
    Coroutine typingCoroutine;

    public TMP_Text talkingName;
    public TMP_Text talkingText;
    public float typeSpeed = 0.1f; // Speed of typewriter effect

    public void Init(SceneScript sc){

        this.sc = sc;
        transform.GetChild(0).gameObject.SetActive(false);
        
    }

    public void Enqueue(string dialogue){

        queue.Add(dialogue);

    }

    public void DisplayNext(){
        
        string who = queue[0].Split('§')[0];
        string dialogue = queue[0].Split('§')[1];

        talkingName.text = who;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(dialogue));

        transform.GetChild(0).gameObject.SetActive(true);
        
        queue.RemoveAt(0);

    }

    public void ContinueDialogue(){

        sc.waitingForDialogue = true;

        if(queue.Count > 0)
            DisplayNext();

        else {

            transform.GetChild(0).gameObject.SetActive(false);
            sc.waitingForDialogue = false;

        }

    }

    //Used for moving the dialogue box during cutscenes.
    public void MoveDialogueBox(float positionX, float positionY){
        RectTransform rect = gameObject.transform.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(positionX, positionY);
    }

    IEnumerator TypeText(string dialogue)
    {
        talkingText.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            talkingText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        sc.waitingForDialogue = false;
    }
}