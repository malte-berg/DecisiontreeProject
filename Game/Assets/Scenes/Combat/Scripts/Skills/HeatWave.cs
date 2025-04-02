using UnityEngine;

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

    public override bool Effect(GameCharacter target1, GameCharacter target2, GameCharacter target3) {
        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt((gc.Strength + gc.GetEquipmentStrengthSum()) * gc.GetEquipmentStrengthMult() * power);

        target1.TakeDamage(Mathf.FloorToInt(damageDealt));
        target2.TakeDamage(Mathf.FloorToInt(damageDealt));
        target3.TakeDamage(Mathf.FloorToInt(damageDealt));

        return true;
    }

}
