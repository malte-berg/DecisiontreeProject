using UnityEngine;
using System.Collections.Generic;

public class HeatWave : Skill {

    public HeatWave() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/HeatWave_Icon"),
        sprites: null,
        gc: null, 
        name: "Heat Wave", 
        power: 0, 
        manaCost: 0, 
        skillCost: 1,
        description: "Deal Fire Damage to all enemies."
        
        ){

    }

    public override bool Effect(GameCharacter target) {
        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt(gc.Magic * power);

        Combat combat = target.c;
        List<Enemy> enemies = combat.Enemies;

        for (int i = enemies.Count - 1; i >= 0; i--) {
            enemies[i].TakeDamage(Mathf.FloorToInt(damageDealt));
        }

        return true;
    }

}
