using System;
using System.Collections;
using UnityEngine;

public class EndCutscene : SceneScript {

    public override IEnumerator RunAnimation() {
        bg.SetBG(23);
        db.MoveDialogueBox(28,-100);

        db.Enqueue(@"
        Narrator§As the fight draws to a close, a final blow from Ynnos sends The Leader pushed backwards. The Leader is too exhausted and injured to fight anymore.
        ");
        db.Enqueue(@"
        The Leader§“<i>URGH!</i>... You… I thought you were poisoned… How are you still so strong?! <b><i>COUGH!</i> <i>COUGH!</i></b>”
        ");
        db.Enqueue(@"
        Ynnos§“Hah… Hah… Haha, I beat you... I did it, huh...”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(24);
        db.MoveDialogueBox(-390,0);

        db.Enqueue(@"
        The Leader§“...Guards!! What are you doing!! <i>COUGH!</i> Kill him now! <b>KILL HIM!!!</b>”
        ");
        db.Enqueue(@"
        Narrator§Three guards enter the Arena, walking towards an exhausted, bloodied Ynnos. 
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(25);
        db.MoveDialogueBox(200,-100);

        db.Enqueue(@"
        Narrator§When they get to him, they unexpectedly stop and look towards The Leader.
        ");
        db.Enqueue(@"
        Guard 1§“...It’s over, Leader.” 
        ");
        db.Enqueue(@"
        Narrator§All three guards walk up to The Leader and begin arresting him.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(26);
        db.MoveDialogueBox(-200,100);

        db.Enqueue(@"
        The Leader§“...Guards!! What are you doing!! <i>COUGH!</i> Kill him now! <b>KILL HIM!!!</b>”
        ");
        db.Enqueue(@"
        Guard 2§“You are not our leader anymore. He is.”
        ");
        db.Enqueue(@"
        Narrator§The guard points at Ynnos. The three guards begin dragging The Leader out of the Arena, taking him to the city jail.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(27);
        db.MoveDialogueBox(50,-180);

        db.Enqueue(@"
        Narrator§As they drag him past Ynnos, one of the guards says quietly to Ynnos…
        ");
        db.Enqueue(@"
        Guard 1§“Samuel is outside. Talk to him. We’ll handle this guy, don’t you worry. Good job, Ynnos.”
        ");
        db.Enqueue(@"
        Narrator§The guard pats Ynnos lightly on the back. It seems these three guards were undercover agents from the Rebellion.
        ");
        db.Enqueue(@"
        Narrator§Ynnos walks out of the Arena, hearing loud cheers from the audience as his victory is announced.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(28);
        db.MoveDialogueBox(300,-100);

        db.Enqueue(@"
        Narrator§As he exits the Arena, he meets up with Samuel. Samuel reaches out his hand for a handshake, but as Ynnos grabs his hand, he is dragged into a big hug from Samuel.
        ");
        db.Enqueue(@"
        Samuel§“You magnificent bastard, you really did it… All these years of suffering, and he’s finally gone….. Thank you Ynnos. Truly, thank you.”
        ");
        db.Enqueue(@"
        Ynnos§“Heh, I’m guessing I did a pretty good job then? Does that mean you’ll give me a raise?”
        ");
        db.Enqueue(@"
        Narrator§As they both chuckle, Samuel soon gets a more serious expression on his face.
        ");
        db.Enqueue(@"
        Samuel§“Now that he’s gone, this is where the real fight begins. Look, Ynnos…”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(29);
        db.MoveDialogueBox(0,-100);

        db.Enqueue(@"
        Samuel§“We’re going to need someone strong. Someone who knows pain… Someone who never gave up, even when seemingly the world was against them.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(16);

        db.Enqueue(@"
        Samuel§“This city doesn’t need a king. It needs a symbol. And today, I believe the symbol we need just stood victorious in that Arena.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(28);
        db.MoveDialogueBox(300,-100);

        db.Enqueue(@"
        Samuel§“Help me rebuild this place, Ynnos. Not as a ruler, but as a protector. For the slums, Ynnos. For the lost. For your sister.”
        ");
        db.Enqueue(@"
        Ynnos§ “No, Samuel. Not just for them, but for the city. For all of them.
        I’ll do it. But only if I get some help.”
        ");
        db.Enqueue(@"
        Samuel§“Of course, Ynnos. Of course. We’ll help you as best we can, don’t worry.
        We’ll make this city a better place together.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(30);
        db.MoveDialogueBox(0,150);

        db.Enqueue(@"
        Narrator§<i>And so, the tyrant fell. The man who tore Ynnos’ family apart was no more. Kirderf had a new leader now — one born in the shadows of oppression, raised through the fire of battle, and driven by hope.</i>
        ");
        db.Enqueue(@"
        Narrator§<i>With the help of Samuel and the Rebellion, Ynnos began reshaping the city.</i>
        ");
        db.Enqueue(@"
        Narrator§<i>Slums were rebuilt, corruption rooted out, and fairness restored — not just for the elite in Highest Heaven, but for the commoners… and for those who came from nothing.</i>
        ");
        db.Enqueue(@"
        Narrator§<i>But while the people of Kirderf celebrated their freedom, a new storm was brewing beyond its walls. Peace is never permanent… and power always attracts the hungry. Especially in this world.</i>
        ");
        db.Enqueue(@"
        Narrator§<i>This is not the end. This is the beginning of something greater. But for now, you may celebrate, you too.</i>
        ");
        db.Enqueue(@"
        Narrator§<i>For a new leader was born today, one who will pave the way for a better future. He would one day become the <b>Ekamer</b>, the prophesied bringer of peace.</i>
        ");
        db.Enqueue(@"
        Narrator§<i>But that’s a story for another day… 
        
            THE END</i>
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }

}