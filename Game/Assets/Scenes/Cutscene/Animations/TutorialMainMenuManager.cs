using System.Collections;
public class TutorialMainMenuManager : SceneScript
{
    public override IEnumerator RunAnimation()
    {
        // Tutorial for main menu
        bg.SetBG(6); // Set main menu background

        db.Enqueue(@"
        Tutorial§Welcome to the Main Menu!
        ");
        db.Enqueue(@"
        Tutorial§In this menu, you'll have access to several important areas of the game.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(2);

        bg.SetBG(7);
        db.MoveDialogueBox(-390, 55);

        db.Enqueue(@"
        Tutorial§Let's start with the 'Inventory Button'.
        ");
        db.Enqueue(@"
        Tutorial§This button takes you to your inventory, where you can manage your items.
        ");
        db.Enqueue(@"
        Tutorial§Here, you can equip or unequip items to strengthen your character.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(-390, 130);

        db.Enqueue(@"
        Tutorial§Next, we have the 'Stats Button'.
        ");
        db.Enqueue(@"
        Tutorial§Clicking this button takes you to your character's stats page.
        ");
        db.Enqueue(@"
        Tutorial§Here, you can view and upgrade stats such as Vitality, Strength and Magic.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(-310, 55);

        db.Enqueue(@"
        Tutorial§The 'Map Button' lets you choose between three unique maps.
        ");
        db.Enqueue(@"
        Tutorial§Each map has its own set of battles and unique store items.
        ");
        db.Enqueue(@"
        Tutorial§This is where you will pick your next adventure.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(-210, 130);

        db.Enqueue(@"
        Tutorial§Then we have the 'Store Button'.
        ");
        db.Enqueue(@"
        Tutorial§Here, you can purchase items using the gold you've earned in battle.
        ");
        db.Enqueue(@"
        Tutorial§You can buy equipment and other useful items.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(-125, 55);

        db.Enqueue(@"
        Tutorial§Next, we have the 'Skill Tree Button'.
        ");
        db.Enqueue(@"
        Tutorial§Clicking this button will take you to your skill tree.
        ");
        db.Enqueue(@"
        Tutorial§Here, you can unlock and upgrade various abilities to enhance your combat skills.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(210, 130);

        db.Enqueue(@"
        Tutorial§Next, in the bottom-right corner, we have the 'Fight Button'.
        ");
        db.Enqueue(@"
        Tutorial§This takes you directly into a battle, using your current stats, items, and skills.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(360, 55);

        db.Enqueue(@"
        Tutorial§You'll also see a 'Wins Counter' here.
        ");
        db.Enqueue(@"
        Tutorial§This shows how many battles you've won so far.
        ");
        db.Enqueue(@"
        Tutorial§It's a great way to track your progress as you get stronger!
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        db.MoveDialogueBox(-180, 135);

        db.Enqueue(@"
        Tutorial§Finally, we have the 'Return Button'.
        ");
        db.Enqueue(@"
        Tutorial§Clicking this sends you back to the Start Menu, where you can start a new game or continue.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(1);

        bg.SetBG(6);
        db.MoveDialogueBox(0, 0);

        db.Enqueue(@"
        Tutorial§That covers all the main buttons in the menu!
        ");
        db.Enqueue(@"
        Tutorial§Make sure to explore these areas to strengthen your character and prepare for battle.
        ");
        db.Enqueue(@"
        Tutorial§Good luck, and enjoy your adventure!
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return WaitForSecs(2);
    }
}
