using UnityEngine;

public class Heal : Skill {
    GameCharacter gc;
    /* private string description = "Regain some lost health.\n" +
                                 "Power: —-\n" +
                                 // "Mana Cost: " + manaCost.ToString() + "\n" + 
                                 "Mana Cost: --\n" + 
                                 "Cooldown: —-\n";

    public string Descrip { get {return description;} } */

    public Heal(GameCharacter gc) : base(gc, "Heal", 1, 0, 1, "Regain some lost health."){
        this.gc = gc;
    }

    public override bool Effect(GameCharacter target){
        if (target != gc) {
            return false;
        }

        if(target.Mana < manaCost)
            return false;

        target.Mana -= manaCost;

        target.HP = target.HP + Mathf.FloorToInt(gc.Magic * power);

        if (target.HP > target.Vitality){
            target.HP = target.Vitality;
        }

        return true;
    }

}
