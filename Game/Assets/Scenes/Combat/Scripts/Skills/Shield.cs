using UnityEngine;

public class Shield : Skill
{

    public Shield() : base(
         icon: null,
         sprites: null,
         gc: null,
         name: "Shield",
         power: 1,
         manaCost: 25,
         skillCost: 1,
         cooldown: 2,
         attack: false,
         description: "Add some armor to player"
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {

        int shieldAdded = -10; // amount of armor gained temporarily

        int shieldTurns = Mathf.FloorToInt( 2 * power); // made this for clarity purpose, power decides turns for now.

        //Add armor to the player character.
        Debug.Log("Shield: Before: " + target.Armor);

        target.statusEffects.Add(new StatusEffect(shieldTurns, shieldAdded, power, 1));
        
        Debug.Log("Shield: After: " + target.Armor);

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Shield animation not implemented yet.");
    }

}
