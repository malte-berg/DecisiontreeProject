using UnityEngine;

public class Shield : Skill
{
    GameCharacter gc;

    // public Shield(GameCharacter gc) : base(
    //     gc: gc,
    //     name: "Shield",
    //     power: 20,
    //     manaCost: 20,
    //     skillCost: 1,
    //     description: "Add some armor to player"
    //     )
    // {
    //     this.gc = gc;
    // }

    public Shield(GameCharacter gc) : base(gc, "Shield", 20, 20, 1)
    {
        this.gc = gc;
    }

    public override bool Effect(GameCharacter target)
    {
        //Only player character can be selected.
        if (target != gc)
        {
            return false;
        }

        if (target.Mana < manaCost)
            return false;

        target.Mana -= manaCost;

        //Add armor to the player character.
        Debug.Log("Before: " + target.Armor);

        target.Armor += Mathf.FloorToInt(10 * power);

        Debug.Log("After: " + target.Armor);

        return true;
    }

}
