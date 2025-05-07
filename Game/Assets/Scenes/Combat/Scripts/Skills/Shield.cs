using UnityEngine;

public class Shield : Skill
{

    public Shield() : base(
         icon: null,
         sprites: null,
         gc: null,
         name: "Shield",
         power: 1,
         manaCost: 0,
         skillCost: 1,
         description: "Add some armor to player"
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {
        //Only player character can be selected.
        if (target != gc)
        {
            return false;
        }
        if (!gc.SpendMana(manaCost))
            return false;

        int shieldAdded = -30; // amount of armor gained temporarily

        int shieldTurns = Mathf.FloorToInt(power); // made this for clarity purpose, power decides turns for now.

        //Add armor to the player character.
        Debug.Log("Shield: Before: " + target.Armor);

        ModifyStatusEffect(target.statusEffects, shieldTurns, shieldAdded, power, 1);

        Debug.Log("Shield: After: " + target.Armor);

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Shield animation not implemented yet.");
    }

}
