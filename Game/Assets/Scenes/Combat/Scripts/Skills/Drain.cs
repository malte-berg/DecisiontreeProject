using UnityEngine;

public class Drain : Skill
{
    GameCharacter gc;

    public Drain(GameCharacter gc) : base(

        gc: gc,
        name: "Drain",
        power: 0,
        manaCost: 100,
        skillCost: 1,
        description: "Reduces enemy's Mana to zero"
    )
    //public Drain(GameCharacter gc) : base(gc, "Drain", 1, 0, 1)
    {
        this.gc = gc;
    }

    public override bool Effect(GameCharacter target)
    {
        if (target == gc)
            return false;
        if (gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        Debug.Log("Drain: Target mana first: " + target.Mana);
        target.Mana = 0;
        Debug.Log("Drain: Target mana after: " + target.Mana);


        return true;

    }

}
