using UnityEngine;

public class Corrode : Skill
{
    GameCharacter gc;

    public Corrode(GameCharacter gc) : base(
        sprites: null,
        gc: gc,
        name: "Corrode",
        power: 0,
        manaCost: 25,
        skillCost: 1,
        description: "Reduces enemy armor"
        )
    {
        this.gc = gc;
    }

    //public Corrode(GameCharacter gc) : base(gc, "Corrode", 0, 25, 1)
    //{
    //    this.gc = gc;
    //}

    public override bool Effect(GameCharacter target)
    {

        if (target == gc)
            return false;
        if (gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        //Target's "Armor" stat decreases.
        if (target.Armor - manaCost < 0)
            target.Armor = 0;
        else
            target.Armor -= manaCost;

        Debug.Log("Corrode gives target an armor of: " + target.Armor);

        return true;
    }
}
