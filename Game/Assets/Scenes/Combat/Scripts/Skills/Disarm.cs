using UnityEngine;

public class Disarm : Skill
{

    public Disarm() : base(
         icon: null,
         sprites: null,
         gc: null,
         name: "Disarm",
         power: 10,
         manaCost: 40,
         skillCost: 1,
         description: "Enemy unequips weapon"
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {

        if (target == gc)
            return false;
        //if (gc.Mana < manaCost)
        //return false;

        if (!gc.SpendMana(manaCost))
            return false;

        //gc.Mana -= manaCost;

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

            //gc.Mana += manaCost;
            gc.SpendMana(-manaCost);
            Debug.Log("Enemy is already unarmed!");
        }

        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Corrode animation not implemented yet.");
    }
}