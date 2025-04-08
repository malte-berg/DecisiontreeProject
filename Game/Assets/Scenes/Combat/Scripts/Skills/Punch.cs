using System;
using UnityEngine;

public class Punch : Skill{
    
    GameCharacter gc;

    public Punch(GameCharacter gc) : base(gc, "Punch", 1, 0, 1){
        this.gc = gc;
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
