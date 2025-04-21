using UnityEngine;

public class Shield : Skill
{
    GameCharacter gc;

    public Shield(GameCharacter gc) : base(
         sprites: null,
         gc: gc,
         name: "Shield",
         power: 1,
         manaCost: 0,
         skillCost: 1,
         description: "Add some armor to player"
         )
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
        if (!gc.SpendMana(manaCost))
            return false;

        int shieldAdded = Mathf.FloorToInt(30 * power); // amount of armor gained temporarily

        //Add armor to the player character.
        Debug.Log("Shield: Before: " + target.Armor);

        Debuff.DebuffStat(target, "armor", shieldAdded);

        Debug.Log("Shield: After: " + target.Armor);

        return true;
    }

}
