using UnityEngine;

public class Exhaust : Skill {
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

    public override bool Effect(){
        if(gc.HP < selfDamage)
            return false;

        gc.Mana += 10;

        if(gc.Mana > gc.maxMana) {
            gc.Mana = gc.maxMana
        }

        gc.HP -= selfDamage;

        return true;
    }
}
