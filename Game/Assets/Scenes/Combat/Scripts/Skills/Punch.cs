using UnityEngine;

public class Punch : Skill
{

    GameCharacter gc;

    public Punch(GameCharacter gc) : base(gc, "Punch", 1, 0, 1, "Perform a basic attack on one enemy.")
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

        int damageDealt = Mathf.FloorToInt(gc.Strength * power);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        return true;

    }

}
