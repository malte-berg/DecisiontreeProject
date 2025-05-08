using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public List<Sprite> sprites;

    public GameCharacter gc;
    string name;
    public float power;
    public int manaCost;
    public int skillCost;
    int skillLevel;
    public bool unlocked;
    int cooldown;
    public int cooldownCount = 0;
    bool attack = true;

    private string description;
    private Sprite icon;
    public string Name { get { return name; } }
    // lägg till beskrivning när man skapar skills/ability
    public string DescriptionPanel { 
        get {
            return $"{description}\nSkill level: {skillLevel}\nMana Cost: {manaCost}\nCooldown: {cooldown}";
        } 
    }
    public int Cooldown { get { return cooldown; } }
    public string Description { get { return description; } }
    public int SkillLevel { get { return skillLevel; } }
    public Sprite Icon { get { return icon; } }

    public Skill(Sprite icon, List<Sprite> sprites, GameCharacter gc, string name, float power, int manaCost, int skillCost, int cooldown, bool attack, string description){
        this.icon = icon;
        this.sprites = sprites;
        this.gc = gc;
        this.name = name;
        this.power = power;
        this.manaCost = manaCost;
        this.skillCost = skillCost;
        this.cooldown = cooldown;
        this.description = description;
        this.attack = attack;
        this.unlocked = false;
        this.skillLevel = 0;
    }

    public void UnlockSkill(GameCharacter who)
    {

        MonoBehaviour.print($"{who.CName} unlocked: {Name}");
        who?.unlockedSkills.Add(this);
        power = 1;
        skillLevel = 1;
        unlocked = true;
        gc = who;

    }

    public void UpgradeSkill(int count = 1) {
        skillLevel += count;
        power = System.MathF.Log(skillLevel, System.MathF.E) + 1;
    }

    public bool TrySkill(GameCharacter target){

        if(target == null)
            return false;
        if(target == gc && attack)
            return false;
        if(target != gc && !attack)
            return false;
        if(gc.Mana < manaCost)
            return false;
        if(cooldownCount > 0)
            return false;

        gc.Mana -= manaCost;
        cooldownCount = cooldown;

        return Effect(target);

    }

    public abstract bool Effect(GameCharacter target);

    public abstract void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm);


    public static void ModifyStatusEffect(List<StatusEffect> statuses, int turns, int delta, float deltaF, int type)
    {
        for(int i = 0; i < statuses.Count; i++)
        {
            if(statuses[i].EffectType == type)
            {
                statuses[i].Turns += turns;
                statuses[i].Delta += delta;
                statuses[i].DeltaF = deltaF;

                Debug.Log("Adding onto existing stat effects"); 
                return;
            }
        }

        statuses.Add(new StatusEffect(turns, delta, deltaF, type));
    }

}