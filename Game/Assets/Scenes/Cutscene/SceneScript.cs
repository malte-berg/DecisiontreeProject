using System.Collections;
using UnityEngine;

public abstract class SceneScript : MonoBehaviour {

    [HideInInspector] public DialogueBox db;
    [HideInInspector] public Backgrounds bg;
    [HideInInspector] public bool waitingForDialogue;

    public void LoadCutscene(DialogueBox db, Backgrounds bg){

        this.db = db;
        this.bg = bg;

    }

    public abstract IEnumerator RunAnimation();

}