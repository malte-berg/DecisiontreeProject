using UnityEngine;

public class Shield : Skill
{

    public Shield() : base(
         icon: Resources.Load<Sprite>("Sprites/Abilities/shield_Icon"),
         sprites: null,
         gc: null,
         name: "Shield",
         power: 1,
         manaCost: 25,
         skillCost: 1,
         cooldown: 2,
         attack: false,
         description: "Add some armor to player",
         soundEffect: null
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {

        int shieldAdded = -10; // amount of armor gained temporarily

        int shieldTurns = Mathf.FloorToInt( 2 * power); // made this for clarity purpose, power decides turns for now.

        //Add armor to the player character.
        target.statusEffects.Add(new StatusEffect(shieldTurns, shieldAdded, power, 1));

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){}

}
