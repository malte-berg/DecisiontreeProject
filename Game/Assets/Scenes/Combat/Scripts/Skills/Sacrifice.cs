using UnityEngine;

public class Sacrifice : Skill {
    GameCharacter gc;
    string name;
    float power;
    int selfDamage;
    int skillCost;

    public Sacrifice(GameCharacter gc) : base(gc){
        this.gc = gc;
        this.name = "Heal";
        this.power = 1;
        this.selfDamage = 10;
        this.skillCost = 0;   
    }

    public override bool Effect(GameCharacter target){
        if (target != gc) {
            return false;
        }

        if(target.HP < selfDamage)
            return false;

        target.Mana += 10 + Mathf.FloorToInt(gc.Strength * power);

        if(target.Mana > target.MaxMana) {
            target.Mana = target.MaxMana;
        }

        target.HP -= selfDamage/(Mathf.FloorToInt(gc.Strength * power));

        return true;
    }
}
