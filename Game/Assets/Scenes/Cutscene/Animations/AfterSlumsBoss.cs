using System.Collections;
using UnityEngine;

public class AfterSlumsBoss : SceneScript
{
    public override IEnumerator RunAnimation() {

        //"guardsEnterSlumsArena" image is set.
        bg.SetBG(9);
        db.MoveDialogueBox(0, -150);

        db.Enqueue(@"
        Narrator§As Ynnos strikes down the last man, more guards storm into the Arena.
        ");
        db.Enqueue(@"
        Ynnos§“Hah… Hah… I can’t fight anymore… Will this truly be the end?“
        ");
        db.Enqueue(@"
        Narrator§Ynnos prepares his final stand, when suddenly a robed man shouts behind him.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();


        //"slumsArenaEscape" image is set.
        bg.SetBG(10);
        db.MoveDialogueBox(-150, 0);
        yield return WaitForSecs(1);

        db.Enqueue(@"
        Robed Man§“Ynnos! Over here! I will help you escape this place!”
        ");
        db.Enqueue(@"
        Narrator§Left with no choice but to trust this man, Ynnos runs towards him. They eventually exit the Arena through a hidden back entrance and end up in a hiding place, seemingly prepared beforehand by the robed man.
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();


        //"slumsRobedConversation" image is set.
        bg.SetBG(11);
        db.MoveDialogueBox(-350, 0);
        yield return WaitForSecs(1);

        db.Enqueue(@"
        Narrator§As Ynnos catches his breath, the robed man gives him a map and a card.
        ");
        db.Enqueue(@"
        Robed Man§“Me and my associates have arranged for you and your sister to live in an apartment in the Commoner’s Quarters.”
        ");
        db.Enqueue(@"
        Robed Man§“That card will get you through the Slums Gate to access the Commoner’s Quarters, and the map will get you the rest of the way.”
        ");
        db.Enqueue(@"
        Robed Man§“You’d better hurry Ynnos. The Argus’ guards will no doubt come after your house here in the Slums any minute and get your sister. Good luck.”
        ");
        db.Enqueue(@"
        Ynnos§“Wait, wait, who are you?! How did you know all this would happen?”
        ");
        db.Enqueue(@"
        Robed Man§“We are the Rebellion, and we will need your power to fight the overlord of this city. We’ll contact you later!”
        ");
        db.Enqueue(@"
        Narrator§As the robed man disappeared, running into the night, Ynnos hurried to his home. He picked up his stuff and got his sister, and together they passed through the Slums Gate.
        ");
        

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        //"ynnosEntersCommQuart" image is set.
        bg.SetBG(12);
        db.MoveDialogueBox(0,0);
        yield return WaitForSecs(1);

        db.Enqueue(@"
        Narrator§After arriving at the apartment and entering their new home, Ynnos find a letter on a table, addressed to him.
        ");
        db.Enqueue(@"
        Contents of letter§<i>Fight in the Arena, Ynnos. We will meet you there, and all will be explained. Don’t die.   - Samuel</i>
        ");

        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);
    }
}
