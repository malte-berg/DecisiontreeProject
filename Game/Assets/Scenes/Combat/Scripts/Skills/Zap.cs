using UnityEngine;
using System;

public class Zap : Skill
{
    GameCharacter gc;

    public Zap(GameCharacter gc) : base(
        sprites: null,
        gc: gc,
        name: "Zap",
        power: 0,
        manaCost: 30,
        skillCost: 1,
        description: "Steals enemy's health while dealing damage"
        )

    //public Zap(GameCharacter gc) : base(gc, "Zap", 2, 30, 1)
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


        // Add 10% of enemies health to player.
        int healAmount = (int)Math.Floor(target.HP * 0.1 * power);

        if (gc.HP + healAmount > gc.Vitality)
            gc.HP = gc.Vitality;
        else
            gc.HP += healAmount;


        //Target takes damage.
        int damageDealt = Mathf.FloorToInt(gc.Strength * power);

        Debug.Log(target.HP);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        Debug.Log("Zap has been activated.");

        return true;

    }
}
