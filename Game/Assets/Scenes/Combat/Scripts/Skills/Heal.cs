using UnityEngine;

public class NewMonoBehaviourScript : Skill {
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

    public override bool Effect(){
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        gc.HP = gc.Vitality

        return true;
    }

}
