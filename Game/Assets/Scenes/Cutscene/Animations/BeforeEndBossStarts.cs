using System;
using System.Collections;
using UnityEngine;

public class BeforeEndBossStarts : SceneScript {

    public override IEnumerator RunAnimation() {
        bg.SetBG(20);
        db.MoveDialogueBox(0,0);

        db.Enqueue(@"
        The Leader§“So, you’re Ynnos…. I’m going to be honest - I expected more. Though you are brave, I will admit that.”
        ");
        db.Enqueue(@"
        Narrator§A confident smirk runs across The Leader’s face.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(21);
        db.MoveDialogueBox(100,0);

        db.Enqueue(@"
        Ynnos§“You turned this city into a hellscape for the poor. You crush anyone who dares speak out against you. You let children starve while you and your ‘nobles’ feasted!”
        ");
        db.Enqueue(@"
        Ynnos§“You <i>kidnap</i> people from their homes to serve in your factories, and you <i>dispose</i> of anyone who refuses!”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(22);
        db.MoveDialogueBox(260,0);

        db.Enqueue(@"
        Ynnos§“<b>You took my parents away, and now you try to take my little sister away too?!</b>” 
        ");
        db.Enqueue(@"
        Ynnos§“All this horrible shit you’ve done, and you show no remorse whatsoever?! Are you even human?! <b><i>NO MORE!</i></b>” 
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(20);
        db.MoveDialogueBox(0,0);

        db.Enqueue(@"
        Ynnos§“...And yet… Despite everything… Despite everything you’ve done to me, to this city, to everyone I know <i>and</i> knew….”
        ");
        db.Enqueue(@"
        Ynnos§“...Your worst mistake was thinking I’d be an easy fight.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        bg.SetBG(22);
        db.MoveDialogueBox(260,0);

        db.Enqueue(@"
        Ynnos§“I haven’t come here to beg, you bastard. I’m here to end you, and to save this city!”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(20);
        db.MoveDialogueBox(0,0);
        
        db.Enqueue(@"
        Narrator§A brief silence falls upon the Arena, as Ynnos’ words resonate within its walls, reaching many of the audience members’ hearts.
        ");
        db.Enqueue(@"
        Narrator§The silence, however, is soon broken through a quiet chuckle from The Leader, growing louder and louder.
        ");
        db.Enqueue(@"
        The Leader§“....hahahAHAHAHA!! I guess I was wrong about this fight - You might just make this enjoyable!”
        ");
        db.Enqueue(@"
        The Leader§“Enough talk, you worm! Come on and entertain me! Your screams of agony shall be music to my ears!!”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }

}