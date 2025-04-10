using UnityEngine;

public class Heal : Skill {
    GameCharacter gc;

    public Heal(GameCharacter gc) : base(

        sprites: null,
        gc: gc,
        name: "Heal",
        power: 0,
        manaCost: 0,
        skillCost: 1,
        description: "Heals the player"
        
        ){

        this.gc = gc;
        
    }

    public override bool Effect(GameCharacter target){
        if (target != gc) {
            return false;
        }

        if(target.Mana < manaCost)
            return false;

        target.Mana -= manaCost;

        target.HP += Mathf.FloorToInt(gc.Magic * power);

        if (target.HP > target.Vitality){
            target.HP = target.Vitality;
        }

        return true;
    }

}
