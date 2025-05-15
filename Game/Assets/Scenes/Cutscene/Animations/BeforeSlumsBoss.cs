using System;
using System.Collections;
using UnityEngine;

public class BeforeSlumsBoss : SceneScript {

    public override IEnumerator RunAnimation() {

        bg.SetBG(8);
        
        db.Enqueue(@"
        Narrator§As Ynnos entered into the grounds of the Arena once more, a group of men in familiar uniforms suddenly storm the Arena. They are guards from the Commoner’s Quarters, the same type of people who raided his home 10 years ago.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);

        db.Enqueue(@"
        Ynnos (thinking)§<i>Who are these bastards? What do they want here?</i>
        ");

        db.MoveDialogueBox(-150, -50);

        db.Enqueue(@"
        Guard Boss§“Who among you is named ‘Ynnos’?”
        ");
        db.Enqueue(@"
        Ynnos§“I am. Who’s asking?”
        ");
        db.Enqueue(@"
        Guard 1§“Congratulations, you’ve been selected to become a worker for Lord Argus. Come with us quickly, or there will be consequences.”
        ");
        db.Enqueue(@"
        Guard 2§“You should feel honored. Not many slum rats like you get the chance to meet a real Lord.”
        ");
        
        db.Enqueue(@"
        Ynnos§“I’m not going anywhere!”
        ");
        db.Enqueue(@"
        Guard Boss§“Then you leave us no choice!”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }

}