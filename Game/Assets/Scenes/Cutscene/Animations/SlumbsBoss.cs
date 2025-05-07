using System.Collections;
using UnityEngine;

public class SlubsBoss : SceneScript {

    public override IEnumerator RunAnimation() {

        yield return new WaitForSeconds(2);

        db.Enqueue(@"Narrator§But something felt wrong...");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        yield return new WaitForSeconds(2);
        db.Enqueue(@"Ynnos§What is this feeling?");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        bg.SetBG(1);

        yield return new WaitForSeconds(1);
        
        db.Enqueue(@"Ynnos§Is that Albert the slub boss?");
        db.Enqueue(@"Ynnos§I have heard stories about this guy, I should be cautious in this fight.");
        db.Enqueue(@"Totally supposed to be called Albert§Hoh hoh hoh, so you are the tough guy that have been beating all my minions.");
        db.Enqueue(@"Totally supposed to be called Albert§Well your time is up, I am here to end your little rebellion!");
        db.ContinueDialogue();
        yield return WaitForDialogue();

    }

}