using System.Collections;
using UnityEngine;

//Always create cutscene scripts which inherits from "SceneScript".
public class SlubsBoss : SceneScript {

    //(Essentially) Only ever run this method.
    public override IEnumerator RunAnimation() {

        yield return new WaitForSeconds(2);

        //Add this text to the dialogue box, with "Narrator" being the name of the character saying the text, and "But something felt wrong..." being what is being said.
        db.Enqueue(@"Narrator§But something felt wrong...");
        db.ContinueDialogue(); //After all dialogue texts have been added, run this method.
        yield return WaitForDialogue(); //If there is more dialogue to come, run this method.

        yield return new WaitForSeconds(2); //Waits for 2 seconds.
        db.Enqueue(@"Ynnos§What is this feeling?");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        bg.SetBG(1);    //Changes the background of the cutscene to background nr. 1, which is set in the "SceneManager" object in the scene.

        yield return new WaitForSeconds(1);
        
        db.Enqueue(@"Ynnos§Is that Albert the slum boss?");
        db.Enqueue(@"Ynnos§I have heard stories about this guy, I should be cautious in this fight.");
        db.Enqueue(@"Totally supposed to be called Albert§Hoh hoh hoh, so you are the tough guy that have been beating all my minions.");
        db.Enqueue(@"Totally supposed to be called Albert§Well your time is up, I am here to end your little rebellion!");
        db.ContinueDialogue();
        yield return WaitForDialogue();

    }

}