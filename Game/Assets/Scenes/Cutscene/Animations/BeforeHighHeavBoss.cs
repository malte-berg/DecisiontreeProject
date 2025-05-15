using System;
using System.Collections;
using UnityEngine;

public class BeforeHighHeavBoss : SceneScript {

    public override IEnumerator RunAnimation() {

        bg.SetBG(19);
        db.MoveDialogueBox(100, 0);

        db.Enqueue(@"
        Narrator§Ynnos walks out of the Arena. He has made a habit of looking around for the robed man every time he exits the Arena, and this time, he actually finds him. Ynnos approaches him.
        ");
        db.Enqueue(@"
        Ynnos§“Hello, Mr…..?”
        ");
        db.Enqueue(@"
        Robed Man§“Hello, Ynnos. Seems you were quicker than normal today. Your habit of looking for me has paid off, huh?”
        ");
        db.Enqueue(@"
        Ynnos§“Wait, how did you-? I couldn’t see you even once… Anyway, you know I still don’t know your name right?”
        ");
        db.Enqueue(@"
        Robed Man§“And you don’t need to. Come on, follow me.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(15);
        db.MoveDialogueBox(-390, 0);

        db.Enqueue(@"
        Narrator§Ynnos follows the robed man, once again entering another secret room and meeting Samuel once again.
        ");
        db.Enqueue(@"
        Samuel§“This is it, Ynnos. Our time has come.”
        ");
        db.Enqueue(@"
        Ynnos§“Uhm… I’m slightly confused right now. What do you mean?”
        ");
        db.Enqueue(@"
        Samuel§“Our guys who work undercover for The Leader have finally managed to convince him to battle in the Arena. Your next fight will be against him, and if you win, you will be the city’s new leader.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(4);
        db.MoveDialogueBox(0,0);

        db.Enqueue(@"
        Narrator§“The next fight will be against The Leader”. The one who stole away Ynnos’ family. As he let each word from Samuel ring in his head again and again, the realization hit him harder and harder. 
        ");
        db.Enqueue(@"
        Narrator§This is the time. Ynnos will finally get his chance at revenge.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(15);
        db.MoveDialogueBox(-390, 0);

        db.Enqueue(@"
        Narrator§At the same time, Ynnos feels nervous. Can he really beat The Leader? The seemingly ‘Strongest in the City’?
        ");
        db.Enqueue(@"
        Ynnos§“...And how do I know I can beat him?”
        ");
        db.Enqueue(@"
        Samuel§“Don’t worry. We believe you have a good chance of beating him. Even The Leader knows this - We had to convince him that we would <i>poison you</i> before the fight in order for him to say yes!”
        ");
        db.Enqueue(@"
        Narrator§Samuel laughs, but Ynnos is still confused.
        ");
        db.Enqueue(@"
        Ynnos§“Okay, but I still don’t understand. Why does he want to fight <i>me</i>?”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(17);
        db.MoveDialogueBox(0,0);

        db.Enqueue(@"
        Samuel§“Ynnos. You are the only one in this city left who can oppose him for real. Neither me nor any of my guys are capable of beating him <i>or</i> his closest guards. That’s why you are our only shot at saving this city.”
        ");
        db.Enqueue(@"
        Samuel§“He wants to fight you to destroy you, before you get even stronger.
        And that will be his last mistake.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(15);
        db.MoveDialogueBox(-390,0);
        
        db.Enqueue(@"
        Narrator§Ynnos stands there for a moment. Is he really the only chance this city has of becoming better? Will his next fight truly decide, once and for all, the future of him and his sister?
        ");
        db.Enqueue(@"
        Narrator§As fear starts to gather inside him, he remembers why he fights. For his kidnapped family. For his sister. For justice. He steels his resolve and says, finally…
        ");
        db.Enqueue(@"
        Ynnos§“....I won’t disappoint you. I’ll defeat him!”
        ");
        db.Enqueue(@"
        Samuel§ “You know, I always saw something special in you Ynnos… I’m glad you decided to join us. After you defeat The Leader, we will help you lead this city to become a better place!”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(12);
        db.MoveDialogueBox(0,0);

        db.Enqueue(@"
        Narrator§Ynnos is determined. He exits the secret room and heads home, preparing as best he can for the fight tomorrow.
        ");
        db.Enqueue(@"
        Narrator§When he wakes up the next day, he sees if his little sister is awake. She’s still sleeping. He gives her one last hug and kisses her gently on the forehead, and exits his home. He's nervous for what’s to come.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(17);

        db.Enqueue(@"
        Narrator§As he walks toward the Arena, he eventually arrives before the entrance. He stops and takes a deep breath. This is it. This is where it all ends.
        It’s time to fight.
        ");
        
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }

}