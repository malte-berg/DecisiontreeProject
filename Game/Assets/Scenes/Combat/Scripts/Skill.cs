using System.Collections.Generic;
using UnityEngine;

public abstract class Skill{
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
    public string Name{ get { return name; } }
    // lägg till beskrivning när man skapar skills/ability
    public string DescriptionPanel { 
        get {
            return $"{description}\nMana Cost: {manaCost}\nCooldown: {cooldown}";
        } 
    }
    public int Cooldown{ get { return cooldown; } }
    public string Description{ get { return description; } }
    public int SkillLevel{ get { return skillLevel; } }
    public Sprite Icon{ get { return icon; } }

    public AudioClip[] soundEffect; 
    private AudioSource audioSource;

    public Skill(Sprite icon, List<Sprite> sprites, GameCharacter gc, string name, float power, int manaCost, int skillCost, int cooldown, bool attack, string description, AudioClip[] soundEffect){
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
        this.soundEffect = soundEffect;
    }

    public void UnlockSkill(GameCharacter who) {

        who?.unlockedSkills.Add(this);
        power = 1;
        skillLevel = 1;
        unlocked = true;
        gc = who;

        audioSource = who.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = who.gameObject.AddComponent<AudioSource>();
        }
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
        cooldownCount = cooldown + 1;

        PlaySound(target);

        return Effect(target);

    }

    private void PlaySound(GameCharacter target){

        GameCharacter character = target.GetComponent<GameCharacter>();

        if (soundEffect != null && soundEffect.Length == 1)
        {
            int index = Random.Range(0, soundEffect.Length);
            audioSource.PlayOneShot(soundEffect[index]);
        } else if (soundEffect.Length > 1 && character.IsPlayer()){ 
            int index = Random.Range(0, soundEffect.Length/2);
            audioSource.PlayOneShot(soundEffect[index]);
        } else {
            int index = Random.Range(soundEffect.Length/2, soundEffect.Length);
            audioSource.PlayOneShot(soundEffect[index]);
        }
    }

    public abstract bool Effect(GameCharacter target);

    public abstract void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm);

}