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
         description: "Removes enemy's weapons"
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {
        Debug.Log("mana: " + gc.Mana);
        //Removes the target's weapon equipment.
        if (target.equipment.weaponLeft != null || target.equipment.weaponRight != null)
        {
            target.equipment.weaponLeft = null;
            target.equipment.weaponRight = null;
            Debug.Log("Disarm: Enemy has been disarmed");
        }

        //If enemy has no weapon equipped, the mana cost is given back.
        else
        {
            gc.Mana += manaCost;
            Debug.Log("Enemy is already unarmed!");
            return false;
        }

        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Disarm animation not implemented yet.");
    }
}