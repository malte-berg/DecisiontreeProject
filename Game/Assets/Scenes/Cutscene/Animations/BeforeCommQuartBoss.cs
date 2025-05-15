using System;
using System.Collections;
using UnityEngine;

public class BeforeCommQuartBoss : SceneScript {

    public override IEnumerator RunAnimation() {

        bg.SetBG(13);

        db.MoveDialogueBox(-400, 0);

        db.Enqueue(@"
        Narrator§Ynnos exits the arena, bloodied and tired after his most recent fight. As he walks towards home, he hears a voice from the dark alley beside him. It was the same robed man as he met when he fled the Slums.
        ");
        db.Enqueue(@"
        Robed Man§“Great work Ynnos. You've sure made a name for yourself.”
        ");
        db.Enqueue(@"
        Ynnos§“So, we meet again. Are you gonna tell me <i>now</i> what this is all about? What do you guys have to do with me? Who really are you people??”
        ");

        db.Enqueue(@"
        Robed Man§“Unfortunately, Ynnos, I cannot tell you anything.”
        ");
        db.Enqueue(@"
        Ynnos§“Well how do you expect me to- !”
        ");
        db.Enqueue(@"
        Robed Man§“But our leader can. He’s waiting for us now, if you will follow me.”
        ");

        db.Enqueue(@"
        Narrator§Ynnos, slightly confused, agrees to meet with this ‘leader’. He wants answers for why all that has happened thus far had to happen to him and his sister. 
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(14);

        db.Enqueue(@"
        Narrator§He follows the robed man further into the alleyway, entering a hidden door to some stairway, leading downwards towards a wooden door.
        ");
        db.Enqueue(@"
        Narrator§As he opens the door, he enters a wide concrete room.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(15);

        db.Enqueue(@"
        Narrator§In the room there are two people, seemingly bodyguards, standing menacingly behind a man wearing old military attire. As Ynnos enters the room, the man in military attire greets him.
        ");

        db.Enqueue(@"
        Military Man, Samuel§“Welcome, Ynnos! The name’s Samuel, glad to finally meet you in person!”
        ");
        db.Enqueue(@"
        Narrator§Ynnos shakes his hand, fairly confused as to why the leader of some “Rebellion” was so glad to meet him.
        ");
        db.Enqueue(@"
        Ynnos§“Alright, so what do you want with me? Why did your guy help me escape from those guards back at the Slums?“
        ");

        db.Enqueue(@"
        Ynnos§“With how quickly he was there to bail me out, it feels like you <i>knew</i> that would happen. How?”
        ");
        db.Enqueue(@"
        Samuel§“A lot of questions, I see. That’s good. I guess I’ll start with who we are and what we do.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        db.MoveDialogueBox(0,0);
        bg.SetBG(16);

        db.Enqueue(@"
        Samuel§“We are the Rebellion. A group of people who are sick with the treatment of the Upper Class towards us Lower Class. ‘<b>The Leader</b>’, the overlord of this city, is a tyrannical dictator that we want to overthrow! We want to bring back peace and prosperity to this city!“
        ");

        db.Enqueue(@"
        Samuel§“To do this, we have worked for years with infiltrating his ranks and learning about his weaknesses. What we have lacked, however, is a definitive force of power that can actually defeat him once and for all. That’s where you come in.”
        ");
        db.Enqueue(@"
        Samuel§“As you know, if the leader of an area is defeated in the Arena, the victor claims that leader’s power. Our plan is to trick The Leader into accepting an Arena fight with you. After you win, we will help you in making this city a truly great place again!”
        ");
        db.Enqueue(@"
        Ynnos§“And how do you expect me to just agree to all this?”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        db.MoveDialogueBox(-400, 0);
        bg.SetBG(15);

        db.Enqueue(@"
        Samuel§“We have watched over you for a long time Ynnos. Many years ago, we saw great potential in you, and it appears we were right. We know you’ll want to join our cause, because if you don’t, The Leader and his forces will forever seek to kill not only you, but also your little sister.”
        ");
        db.Enqueue(@"
        Ynnos§“....Alright. I’m in. If it means my sister has a good future ahead of her, I’ll do any task!”
        ");
        db.Enqueue(@"
        Samuel§“Great! Your next Arena fight will be against a Gladiator, sent by The Leader to kill you.”
        ");

        db.Enqueue(@"
        Samuel§“The Leader has already learnt of the potential threat you pose to him, but we have made him misjudge your power. We expect you to be able to win against his gladiator, and when you do, you will take his ‘Fighter Pass’ and give it to us, so that we can forge a fake one for you!”
        ");
        db.Enqueue(@"
        Ynnos§“A ‘<i>Fighter Pass</i>’? What’s that?”
        ");
        db.Enqueue(@"
        Samuel§“It’s a card, much like the card my associate gave you to pass through the Slums Gate.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(17);

        db.Enqueue(@"
        Samuel§“It gives you access to the finest place in this city: ‘<i>Highest Heaven</i>’. With a ‘Fighter Pass’, you can enter the Arena there, which is the only Arena we believe we can make The Leader fight in.”
        ");
        db.Enqueue(@"
        Samuel§“We want you to fight in that Arena and make a name for yourself. Eventually, we will convince The Leader to schedule a fight with you. Do you accept this mission?”
        ");
        db.Enqueue(@"
        Ynnos§“Well, what other choice do I have? I accept!”
        ");
        db.Enqueue(@"
        Samuel§“Good! Then we will meet again once you’ve defeated the guard commander. Don’t worry, we’ll find you.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        db.MoveDialogueBox(0,0);
        bg.SetBG(12);

        db.Enqueue(@"
        Narrator§Ynnos exits the secret room and goes home. As he prepares for the fight ahead, he feels scared of what’s to come, but also hopeful.
        Ynnos had tried for a long time to find a way to make a better life for him and his sister. Now, he finally knows exactly what he needs to do.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }

}