using UnityEngine;

public class Heal : Skill {
    
    public Heal() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/Heal_Icon"),
        sprites: null,
        gc: null,
        name: "Heal",
        power: 0,
        manaCost: 0,
        skillCost: 1,
        description: "Regain some lost health."
        
        ){

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
