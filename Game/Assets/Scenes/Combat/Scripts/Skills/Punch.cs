using System;
using System.Collections.Generic;
using UnityEngine;

public class Punch : Skill
{

    GameCharacter gc;

    public Punch(GameCharacter gc) : base(

        sprites: new List<Sprite> { Resources.Load<Sprite>("Sprites/Abilities/punchAnimation") },
        gc: gc,
        name: "Punch",
        power: 0,
        manaCost: 1,
        skillCost: 1,
        description: "Perform a basic attack on one enemy."

        )
    {

        this.gc = gc;

    }

    public override bool Effect(GameCharacter target)
    {

        if (target == gc)
            return false;
        //if (gc.Mana < manaCost)
        Debug.Log("Mana of person using punch: " + gc.Mana + "Name: " + gc.CName + " and its used on: " + target.CName);
        if (!gc.SpendMana(manaCost))
            return false;

        //gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt(gc.Strength * power);
        target.TakeDamage(damageDealt);

        return true;

    }

}