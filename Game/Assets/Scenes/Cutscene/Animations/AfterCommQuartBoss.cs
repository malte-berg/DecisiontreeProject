using System;
using System.Collections;
using UnityEngine;

public class AfterCommQuartBoss : SceneScript {

    public override IEnumerator RunAnimation() {

        //"TheMiracle" image is set.
        bg.SetBG(18);
        db.MoveDialogueBox(-250, 0);

        db.Enqueue(@"
        Narrator§As the mighty gladiator finally falls, Ynnos hurries to him, sneakily taking what seems to be his ‘Fighter Pass’. When Ynnos exits the Arena once more, the same robed man greets him.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(13);
        db.MoveDialogueBox(-370, 0);

        db.Enqueue(@"
        Robed Man§“Great work, Ynnos. It was a good fight. The Fighter Pass?”
        ");
        db.Enqueue(@"
        Narrator§Ynnos hands it over, the robed man putting it in the inside pocket of his robe.
        ");
        db.Enqueue(@"
        Robed Man§“We’ll deliver the completed fake pass in a few days. In the meantime, try to lay low.”
        ");
        db.Enqueue(@"
        Ynnos§“And what will I do after that?”
        ");
        db.Enqueue(@"
        Robed Man§“Continue doing what you do best. Fight in the Arena. Go to Highest Heaven and defeat as many fighters there as you can. We will contact you when it is time.”
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(0.5f);
        bg.SetBG(12);
        db.MoveDialogueBox(0, 0);

        db.Enqueue(@"
        Narrator§The robed man then runs away, disappearing much the same as he did in the Slums. Ynnos goes back home, taking care of his sister and laying low as much as he can.
        ");
        db.Enqueue(@"
        Narrator§After a few days, he sees a small package that has slipped under his door. As he opens it, he finds what seems to be a Fighter’s Pass, but with his initials on it. 
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
        bg.SetBG(17);

        db.Enqueue(@"
        Narrator§Ynnos goes to Heaven’s Gate at the end of the Commoner’s Quarters, and manages to pass through. As he goes up the hill, he sees more and more of the largest Arena in the city: ‘<i>Heaven’s Arena</i>’.
        ");
        db.Enqueue(@"
        Narrator§Standing outside the Arena, he steels his resolve once again. It is nearly time to get his revenge from all those years ago, when guards sent by The Leader stole away his family. 
        It is time to fight.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }

}