using UnityEngine;

public abstract class Skill{

    GameCharacter gc;
    string name;
    float power;
    int manaCost;
    int skillCost;

    public string Name{ get { return name; } }

    public Skill(GameCharacter gc){

        this.gc = gc;

    }

    public void UnlockSkill() {

        power = 1;

    }

    public void UpgradeSkill() {

        power = System.MathF.Log(System.MathF.Pow(System.MathF.E, power) + 1, System.MathF.E);

    }

    public abstract bool Effect(GameCharacter target);

}
