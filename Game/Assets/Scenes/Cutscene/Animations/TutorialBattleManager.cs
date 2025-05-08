using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBattleManager : SceneScript
{
    public override IEnumerator RunAnimation()
    {
        bg.SetBG(10); // Set combat background

        db.Enqueue(@"
        Tutorial§Welcome to the battle arena!
        ");
        db.Enqueue(@"
        Tutorial§In this tutorial, we’ll walk you through the basic elements of combat.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return new WaitForSeconds(1);

        db.MoveDialogueBox(100, 170);

        db.Enqueue(@"
        Tutorial§Each character has a 'Health Bar' (in green) and a 'Mana Bar' (in blue) above them.
        ");
        db.Enqueue(@"
        Tutorial§Health represents how much damage a character can take — if it reaches zero, they’re defeated.
        ");
        db.Enqueue(@"
        Tutorial§Mana is a resource used to activate certain skills.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return new WaitForSeconds(1);

        bg.SetBG(11);
        db.MoveDialogueBox(-390, 120);

        db.Enqueue(@"
        Tutorial§At the bottom left of the screen, you’ll see your 'Ability Bar'.
        ");
        db.Enqueue(@"
        Tutorial§This bar displays all the skills your character currently owns.
        ");
        db.Enqueue(@"
        Tutorial§To use a skill during battle, you would normally click the skill icon, then select a target.
        ");
        db.Enqueue(@"
        Tutorial§For example, using 'Punch' on an enemy would deal damage based on your character's stats.
        ");
        db.Enqueue(@"
        Tutorial§Once a skill is executed, the enemy’s health bar will decrease accordingly.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return new WaitForSeconds(1);

        db.MoveDialogueBox(0, 120);

        db.Enqueue(@"
        Tutorial§Next, we have the 'Ability Description'.
        ");
        db.Enqueue(@"
        Tutorial§Here, you can view the description of the applied ability such as the skill level, the mana cost and the cooldown.
        ");
        db.Enqueue(@"
        Tutorial§Each skill has its own purpose — for example, 'Punch' is a simple physical attack that costs no Mana.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return new WaitForSeconds(1);

        db.MoveDialogueBox(390, 120);

        db.Enqueue(@"
        Tutorial§In the bottom-right corner, you’ll find the 'Flee' button.
        ");
        db.Enqueue(@"
        Tutorial§Clicking this button allows you to flee from battle.
        ");
        db.Enqueue(@"
        Tutorial§Running is useful if you're overwhelmed or want to retreat to fight another time.
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return new WaitForSeconds(1);

        bg.SetBG(10);
        db.MoveDialogueBox(0, 0);

        db.Enqueue(@"
        Tutorial§That covers the core elements of the battle interface.
        ");
        db.Enqueue(@"
        Tutorial§Good luck on your adventure, and may your tactics lead you to victory!
        ");
        db.ContinueDialogue();
        yield return WaitForDialogue();
        yield return new WaitForSeconds(2);
    }
}
