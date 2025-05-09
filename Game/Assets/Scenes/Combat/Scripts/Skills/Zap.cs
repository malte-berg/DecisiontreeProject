using UnityEngine;
using System;

public class Zap : Skill
{

    public Zap() : base(
        icon: null,
        sprites: null,
        gc: null,
        name: "Zap",
        power: 1,
        manaCost: 30,
        skillCost: 1,
        cooldown: 2,
        attack: true,
        description: "Steals enemy's health while dealing damage"
        )
    {

    }

    public override bool Effect(GameCharacter target)
    {


        // Add 10% of enemies health to player.
        int healAmount = (int)Math.Floor(target.HP * 0.1 * power);

        Debug.Log("HP before: " + gc.HP + " and health added: " + healAmount);

        gc.HP = Mathf.Clamp(gc.HP + healAmount, 0, gc.Vitality);
        
        //Target takes damage.
        int damageDealt = Mathf.FloorToInt(gc.Strength * power);

        Debug.Log("HP after: " + gc.HP);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        Debug.Log("Zap has been activated.");

        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Zap animation not implemented yet.");
    }
}
