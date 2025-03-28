using UnityEngine;

public class Punch : Skill{
    
    GameCharacter gc;
    int manaCost;

    public Punch(GameCharacter gc, int manaCost) : base(gc, manaCost){
        this.gc = gc;
        this.manaCost = manaCost;
    }

    public override bool Effect(GameCharacter target){

        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;
        target.TakeDamage(gc.DMG);

        return true;

    }

}
