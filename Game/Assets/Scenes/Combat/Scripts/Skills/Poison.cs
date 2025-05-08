using System;
using UnityEngine;

// ----------------------------------------------------------------------------
//  This will not work until we have implemented passive effects. Dont mind it.
//-------------------------------------------------------------------------------
public class Poison : Skill
{
    GameCharacter gc;
    int turnsLeft;
    bool active;

    //public Poison(GameCharacter gc) : base(gc, "Poison", 10, 40, 1)
    //{
    //    this.gc = gc;
    //}

    public Poison(GameCharacter gc) : base(
         icon: null,
         sprites: null,
         gc: gc,
         name: "Poison",
         power: 10,
         manaCost: 40,
         skillCost: 1,
        cooldown: 0,
        attack: true,
         description: "Deals poison damage for 3 turns"
         )
    {
        this.gc = gc;
    }

    //Selected enemy takes damage each turn for 3 turns.
    public override bool Effect(GameCharacter target)
    {
        // if (target == gc)
        //     return false;
        // if (gc.Mana < manaCost)
        //     return false;


        // active = target.c.passiveIsActive;

        // //Check if the passive effect has been activated yet or not.
        // if (active == false)
        // {
        //     gc.Mana -= manaCost;

        //     target.c.passiveEffect = this;  //The passiv eeffect should be this
        //     target.c.passiveIsActive = true;    //In Combat, the passive effect should be active.
        //     turnsLeft = 3;  //Poison acts for 3 turns
        //     Debug.Log("Activate Poison effect");
        // }

        // //If the passive effect still has turns left in which it should activate, this should happen.
        // else if (turnsLeft > 0)
        // {
        //     //Damage the enemy each turn.
        //     int damageDealt = Mathf.FloorToInt(10);

        //     target.TakeDamage(Mathf.FloorToInt(damageDealt));

        //     turnsLeft--;    //Reduce the amount of turns left until the effect ends.

        //     Debug.Log("Poison damages enemy");
        // }

        // //If there are no turns left for this effect, it ends.
        // else
        // {
        //     Debug.Log("Poison ends");

        //     target.c.passiveIsActive = false;
        //     active = false;
        // }



        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Corrode animation not implemented yet.");
    }

}