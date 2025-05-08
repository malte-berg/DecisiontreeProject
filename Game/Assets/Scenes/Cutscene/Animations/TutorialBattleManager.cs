using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBattleManager : SceneScript
{
    public override IEnumerator RunAnimation()
    {
        bg.SetBG(7); // Set battle background

        db.Enqueue("Tutorial§Welcome to your first battle!");
        db.Enqueue("Tutorial§In this tutorial, we’ll walk you through the basic elements of combat.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§At the bottom left of the screen, you’ll see your **Ability Bar**.");
        db.Enqueue("Tutorial§This bar displays all the skills your character currently owns.");
        db.Enqueue("Tutorial§Each skill has its own purpose — for example, 'Punch' is a simple physical attack that costs no Mana.");
        db.Enqueue("Tutorial§Skills that cost Mana will display their Mana cost beside their icon.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§To use a skill during battle, you would normally click the skill icon, then select a target.");
        db.Enqueue("Tutorial§For example, using 'Punch' on an enemy would deal damage based on your character's stats.");
        db.Enqueue("Tutorial§Once a skill is executed, the enemy’s health bar will decrease accordingly.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Now, look at the middle of the screen — this is where the characters are displayed.");
        db.Enqueue("Tutorial§Each character has a **Health Bar** (in green) and a **Mana Bar** (in blue) above them.");
        db.Enqueue("Tutorial§Health represents how much damage a character can take — if it reaches zero, they’re defeated.");
        db.Enqueue("Tutorial§Mana is a resource used to activate certain skills.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Pay attention to the green marker above the characters.");
        db.Enqueue("Tutorial§This marker shows **whose turn it currently is** in the battle.");
        db.Enqueue("Tutorial§When the green marker appears above a character, that character can act — using a desired skill to attack.");
        db.Enqueue("Tutorial§Use this to track when it's your turn and when enemies are about to act.");
        db.ContinueDialogue();
        yield return WaitForDialogue();


        db.Enqueue("Tutorial§In the bottom-right corner, you’ll find the **Run** button.");
        db.Enqueue("Tutorial§Clicking this button allows you to flee from battle.");
        db.Enqueue("Tutorial§Running is useful if you're overwhelmed or want to retreat to fight another time.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§That covers the core elements of the battle interface.");
        //db.Enqueue("Tutorial§Once this tutorial ends, you’ll be able to take control and fight the enemies yourself.");
        db.Enqueue("Tutorial§Good luck on your adventure, and may your tactics lead you to victory!");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        yield break;
    }
}
