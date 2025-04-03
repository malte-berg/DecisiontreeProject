using UnityEngine;

public class Heal : Skill {
    GameCharacter gc;
    string name;
    float power;
    int manaCost;
    int skillCost;

    public Heal(GameCharacter gc) : base(gc){
        this.gc = gc;
        this.name = "Heal";
        this.power = 1;
        this.manaCost = 0;
        this.skillCost = 0;
        
    }

    public override bool Effect(GameCharacter target){
        if (target != gc) {
            return false;
        }

        if(target.Mana < manaCost)
            return false;

        target.Mana -= manaCost;

        target.HP = target.HP + Mathf.FloorToInt(gc.Strength * power);;

        return true;
    }

}
