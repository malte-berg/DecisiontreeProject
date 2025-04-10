using UnityEngine;

public class Disarm : Skill
{
    GameCharacter gc;

    public Disarm(GameCharacter gc) : base(
         sprites: null,
         gc: gc,
         name: "Disarm",
         power: 10,
         manaCost: 40,
         skillCost: 1,
         description: "Enemy unequips weapon"
         )
    {

        this.gc = gc;
    }

    //public Disarm(GameCharacter gc) : base(gc, "Disarm", 10, 40, 1)
    //{
    //  this.gc = gc;
    //}


    public override bool Effect(GameCharacter target)
    {

        if (target == gc)
            return false;
        if (gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        //Target takes damage.
        //int damageDealt = Mathf.FloorToInt(gc.Strength * power);
        int damageDealt = Mathf.FloorToInt(20);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        //Removes the target's weapon equipment.
        if (!(target.equipment.weaponLeft == null && target.equipment.weaponRight == null))
        {
            target.equipment.weaponLeft = null;
            target.equipment.weaponRight = null;
            Debug.Log("Disarm: Enemy has been disarmed");
        }

        //If enemy has no weapon equipped, the mana cost is given back.
        else
        {
            gc.Mana += manaCost;
            Debug.Log("Enemy is unarmed!");
        }

        return true;

    }
}