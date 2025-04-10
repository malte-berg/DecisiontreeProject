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
    string description;
    int cooldown = 0;

    public string Name{ get { return name; } }
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
    }

    public void UnlockSkill() {

        power = 1;
        skillLevel = 1;
        unlocked = true;

    }

    public void UpgradeSkill() {
        power = System.MathF.Log(System.MathF.Pow(System.MathF.E, power) + 1, System.MathF.E);
        skillLevel++;
    }

    public abstract bool Effect(GameCharacter target);

}