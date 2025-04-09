using UnityEngine;

public abstract class Skill{

    GameCharacter gc;
    public string name;
    public float power;
    public int manaCost;
    public int skillCost;
    public bool unlocked;

    private string description;
    public string Name{ get { return name; } }
    // lägg till beskrivning när man skapar skills/ability
    public string Description { 
        get {
            return description +
                   "Skill level: —-\n" + // vissa skill level istället för power?
                   "Mana Cost: " + manaCost.ToString() + "\n" +  
                   "Cooldown: —-\n"; 
        } 
    }

    public Skill(GameCharacter gc, string name, float power, int manaCost, int skillCost, string description){

        this.gc = gc;
        this.name = name;
        this.power = power;
        this.manaCost = manaCost;
        this.skillCost = skillCost;
        this.description = description;
        this.unlocked = false;
    }

    public void UnlockSkill() {

        power = 1;
        unlocked = true;

    }

    public void UpgradeSkill() {
        power = System.MathF.Log(System.MathF.Pow(System.MathF.E, power) + 1, System.MathF.E);
    }

    public abstract bool Effect(GameCharacter target);

}