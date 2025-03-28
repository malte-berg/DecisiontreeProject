using UnityEngine;

public class Punch : Skill{
    
    GameCharacter gc;
    string name;
    float power;
    int manaCost;
    int skillCost;

    public Punch(GameCharacter gc, string name, float power, int manaCost, int skillCost) : base(gc, name, power, manaCost, skillCost){

        this.gc = gc;
        this.name = name;
        this.power = 1;
        this.manaCost = manaCost;
        this.skillCost = skillCost;
        
    }

    public override bool Effect(GameCharacter target){

        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt((gc.Strength + gc.GetEquipmentStrengthSum()) * gc.GetEquipmentStrengthMult() * power);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        return true;

    }

}
