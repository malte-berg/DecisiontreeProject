using UnityEngine;
using System.Collections.Generic;

public class HeatWave : Skill {
     GameCharacter gc;
    string name;
    float power;
    int manaCost;
    int skillCost;

    public HeatWave(GameCharacter gc) : base(gc) {
        this.gc = gc;
        this.name = "Heat Wave";
        this.power = 1;
        this.manaCost = 0;
        this.skillCost = 0;
    }

    public override bool Effect(GameCharacter target) {
        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt(gc.Strength * power);

        Combat combat = target.c;
        List<Enemy> enemies = combat.Enemies;

        foreach (GameCharacter enemy in enemies){
            enemy.TakeDamage(Mathf.FloorToInt(damageDealt));
        }

        return true;
    }

}
