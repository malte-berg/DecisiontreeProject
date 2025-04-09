using System;
using UnityEngine;

public class Punch : Skill
{

    GameCharacter gc;

    public Punch(GameCharacter gc) : base(

        gc: gc,
        name: "Punch",
        power: 0,
        manaCost: 0,
        skillCost: 1,
        description: "The simplest and purest of attacks"

        )
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

        target.TakeDamage(damageDealt);

        return true;

    }

}
