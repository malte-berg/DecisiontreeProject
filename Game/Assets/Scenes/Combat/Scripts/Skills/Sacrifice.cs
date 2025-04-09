using UnityEngine;
using System;

public class Sacrifice : Skill
{
    GameCharacter gc;
    int selfDamage;

    public Sacrifice(GameCharacter gc) : base(

        gc: gc,
        name: "Sacrifice",
        power: 0,
        manaCost: 0,
        skillCost: 1,
        description: "Inflict damage on yourself to gain mana"

        )
    {

        this.gc = gc;
        this.selfDamage = 10;

    }

    public override bool Effect(GameCharacter target)
    {
        if (target != gc)
        {
            return false;
        }

        if (target.HP < selfDamage)
            return false;

        target.Mana += 10 + (int)Math.Floor((0.9 * gc.Strength) * (0.1 * gc.Magic) * power);

        if (target.Mana > target.MaxMana)
        {
            target.Mana = target.MaxMana;
        }

        target.HP -= Mathf.FloorToInt(selfDamage / (gc.Strength * power));

        return true;
    }
}
