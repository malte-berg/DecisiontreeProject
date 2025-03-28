using UnityEngine;

public abstract class Skill{

    GameCharacter gc;
    string name;
    float power;
    int manaCost;
    int skillCost;

    public string Name{ get { return name; } }

    public Skill(GameCharacter gc, string name, float power, int manaCost, int skillCost){

        this.gc = gc;
        this.name = name;
        this.power = 1;
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
