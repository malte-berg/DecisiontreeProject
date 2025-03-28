using UnityEngine;

public abstract class Skill{

    GameCharacter gc;
    float power = 0;
    int manaCost;
    int skillCost;

    public Skill(GameCharacter gc, int manaCost, int skillCost){

        this.gc = gc;
        this.manaCost = manaCost;
        this.skillCost = skillCost;

    }

    public void UnlockSkill() {

        power = 1;

    }

    public void UpgradeSkill() {

        power = System.MathF.Log(System.MathF.Pow(System.MathF.E, power) + 1, System.MathF.E);

    }

    public abstract bool Effect(GameCharacter target);

}
