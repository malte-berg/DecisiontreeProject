using UnityEngine;

public class Disarm : Skill
{

    public Disarm() : base(
         icon: null,
         sprites: null,
         gc: null,
         name: "Disarm",
         power: 1,
         manaCost: 40, 
         skillCost: 1,
         cooldown: 3,
         attack: true,
         description: "Removes enemy's weapons.",
         soundEffect: null
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {
        //Removes the target's weapon equipment.
        if (target.equipment.weaponLeft != null || target.equipment.weaponRight != null)
        {
            target.equipment.weaponLeft = null;
            target.equipment.weaponRight = null;
        }

        //If enemy has no weapon equipped, the mana cost is given back.
        else
        {
            gc.Mana += manaCost;
            return false;
        }

        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){}
}