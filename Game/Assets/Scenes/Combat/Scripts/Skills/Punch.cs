using UnityEngine;

public class Punch : Skill{
    
    GameCharacter gc;
    float power = 0;
    int manaCost;
    int skillCost;

    public Punch(GameCharacter gc, int manaCost, int skillCost) : base(gc, manaCost, skillCost){

        this.gc = gc;
        this.manaCost = manaCost;
        this.skillCost = skillCost;
        
    }

    public override bool Effect(GameCharacter target){

        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt((
          (gc.Magic * 0)
        + (gc.Strength * 1 * gc.GetEquipmentStrengthMult()) // add item scaling
        + (15)
        ) * power);

        target.TakeDamage(Mathf.FloorToInt(gc.DMG * power));

        return true;

    }

}
