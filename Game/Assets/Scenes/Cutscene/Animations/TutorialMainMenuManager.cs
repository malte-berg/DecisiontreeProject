using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMainMenuManager : SceneScript
{
    public override IEnumerator RunAnimation()
    {
        bg.SetBG(8); // Set main menu background

        db.Enqueue("Tutorial§Welcome to the Main Menu!");
        db.Enqueue("Tutorial§In this menu, you'll have access to several important areas of the game.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Let’s start with the **Inventory Button**.");
        db.Enqueue("Tutorial§This button takes you to your inventory, where you can manage your items.");
        db.Enqueue("Tutorial§Here, you can equip or unequip items to strengthen your character.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Next, we have the **Stats Button**.");
        db.Enqueue("Tutorial§Clicking this button takes you to your character's stats page.");
        db.Enqueue("Tutorial§Here, you can view and upgrade stats such as Vitality, Strength, and Magic.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§The **Map Button** lets you choose between three unique maps.");
        db.Enqueue("Tutorial§Each map has its own set of battles and unique store items.");
        db.Enqueue("Tutorial§This is where you will pick your next adventure.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Then we have the **Store Button**.");
        db.Enqueue("Tutorial§Here, you can purchase items using the gold you've earned in battle.");
        db.Enqueue("Tutorial§You can buy equipment and other useful items.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Finally, there’s the **Skill Tree Button**.");
        db.Enqueue("Tutorial§Clicking this button will take you to your skill tree.");
        db.Enqueue("Tutorial§Here, you can unlock and upgrade various abilities to enhance your combat skills.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§Finally, in the **top-right corner**, you’ll see the **Fight Button**.");
        db.Enqueue("Tutorial§This takes you directly into a battle, using your current stats, items, and skills.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§In the **bottom-right corner**, you'll find the **Return Button**.");
        db.Enqueue("Tutorial§Clicking this sends you back to the Start Menu, where you can start a new game or continue.");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        db.Enqueue("Tutorial§That covers all the main buttons in the menu!");
        db.Enqueue("Tutorial§Make sure to explore these areas to strengthen your character and prepare for battle.");
        db.Enqueue("Tutorial§Good luck, and enjoy your adventure!");
        db.ContinueDialogue();
        yield return WaitForDialogue();

        yield break;
    }
}
