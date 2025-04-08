using System;
using UnityEngine;

public class Punch : Skill{
    
    GameCharacter gc;
    string name;
    float power;
    int manaCost;
    int skillCost;

    public Punch(GameCharacter gc) : base(gc){

        this.gc = gc;
        this.name = "Punch";
        this.power = 1;
        this.manaCost = 0;
        this.skillCost = 0;
        
    }

    public override bool Effect(GameCharacter target){

        if(target == gc)
            return false;

        if(gc.Mana < manaCost)
            return false;
        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt(gc.Strength * power);
        try{

        target.TakeDamage(damageDealt);

        } catch (Exception e) {
            Debug.LogError(e.Message);
        }
        return true;

    }

}
