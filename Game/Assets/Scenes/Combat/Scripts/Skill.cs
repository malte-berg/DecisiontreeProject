using System.Collections.Generic;
using UnityEngine;

public abstract class Skill{
    public List<Sprite> sprites;

    GameCharacter gc;
    string name;
    public float power;
    public int manaCost;
    public int skillCost;
    int skillLevel;
    public bool unlocked;
    int cooldown = 0;

    private string description;
    public string Name{ get { return name; } }
    // lägg till beskrivning när man skapar skills/ability
    public string DescriptionPanel { 
        get {
            return description +
                   "Skill level: —-\n" + // vissa skill level istället för power?
                   "Mana Cost: " + manaCost.ToString() + "\n" +  
                   "Cooldown: —-\n"; 
        } 
    }
    public int Cooldown{ get { return cooldown; } }
    public string Description{ get { return description; } }
    public int SkillLevel{ get { return skillLevel; } }

    public Skill(List<Sprite> sprites, GameCharacter gc, string name, float power, int manaCost, int skillCost, string description){

        this.sprites = sprites;
        this.gc = gc;
        this.name = name;
        this.power = power;
        this.manaCost = manaCost;
        this.skillCost = skillCost;
        this.description = description;
        this.unlocked = false;
        this.skillLevel = 0;
    }

    public void UnlockSkill() {

        power = 1;
        skillLevel = 1;
        unlocked = true;

    }

    public void UpgradeSkill() {
        skillLevel++;
        power = System.MathF.Log(skillLevel, System.MathF.E) + 1;
    }

    public abstract bool Effect(GameCharacter target);

}