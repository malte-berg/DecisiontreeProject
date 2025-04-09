using UnityEngine;

//  We could not find a good way to make this work...
public class MindControl : Skill
{
    GameCharacter gc;

    // public MindControl(GameCharacter gc) : base( 

    //     gc: gc,
    //     name: "Mind Control",
    //     power: 10,
    //     manaCost: 40,
    //     skillCost: 1,
    //     description: "Makes enemy attack other enemies"
    //     )
    // {
    //     this.gc = gc;
    // }

    public MindControl(GameCharacter gc) : base(gc, "Mind Control", 10, 40, 1)
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

        //Enemy targets another enemy, instead of the player.

        return true;

    }
}