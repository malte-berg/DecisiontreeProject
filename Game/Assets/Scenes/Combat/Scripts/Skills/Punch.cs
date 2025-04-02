using UnityEngine;

public class Punch : Skill{
    
    GameCharacter gc;
<<<<<<< HEAD
    string name;
    float power;
=======
    float power = 1;
>>>>>>> 9a62df7d (Added UI for skill tree options)
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

        int damageDealt = Mathf.FloorToInt((gc.Strength + gc.GetEquipmentStrengthSum()) * gc.GetEquipmentStrengthMult() * power);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        return true;

    }

}
