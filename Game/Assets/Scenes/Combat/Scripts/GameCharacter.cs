using System.Threading.Tasks;
using UnityEngine;

public class GameCharacter : MonoBehaviour{

    Combat c;

    // STATS
    int hp = 100;
    int vitality = 100;
    int armor = 5;
    int strength = 10;
    int magic = 1;
    int mana = 100;
    public int Strength{get { return strength; }}
    public int Magic{get { return magic; }}
    public int Mana{get{ return mana; } set{ this.mana = value; }}
    public int HP{get{ return hp; } set{ this.hp = value; }}

    // SKILLS
    public Skill[] skills;
    int skillCount = 1;
    int selectedSkill = 0;

    // INVENTORY
    Equipment equipment;
    Item[] inventory;

    public GameCharacter(int hp, int vitality, int armor, int strength, int magic, int mana, int skillCount){

        this.hp = hp;
        this.vitality = vitality;
        this.armor = armor;
        this.strength = strength;
        this.magic = magic;
        this.mana = mana;
        this.skills = new Skill[8];
        this.skillCount = skillCount;
        this.equipment = null;
        this.inventory = new Item[20];

    }

    public void Init(Combat c){

        this.c = c;
        equipment = gameObject.AddComponent<Equipment>();

        // TEMP DEBUG
        skills[0] = new Punch(this, "Punch", 1, 20, 0);

        if(gameObject.name == "Player") {

            inventory[0] = new Weapon("Excalibur", 9999, 10, 1.2f, 5, 1.1f, 224, 10.7f, 23, 1.2f, 162, 1.2f);
            equipment.Equip(inventory[0]);

        }

    }

    void OnMouseDown(){

        c.CharacterClicked(this);

    }

    public bool UseSkill(GameCharacter target){

        print(gameObject.name + " is using " + skills[selectedSkill].Name + " on " + target.gameObject.name);
        return skills[selectedSkill].Effect(target);

    }

    public void TakeDamage(int dmg){

        if(dmg <= armor)
            return;

        hp -= dmg - armor;
        print(gameObject.name + " took: " + dmg + " damage!");

        if(hp <= 0)
            c.KillCharacter(this);
        else
            DamageEffect();

    }

    async Task DamageEffect(){

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        float time = 0.5f;
        
        while(time > 0){

            sr.color = new Color(1,1-time,1-time);
            time -= Time.deltaTime;
            await Task.Yield();

        }
            
        sr.color = new Color(1,1,1);

    }

    public float GetEquipmentVitalityMult(){

        float factor = 1;
        if(equipment.head != null)
            factor *= equipment.head.VitalityMult;
        if(equipment.torso != null)
            factor *= equipment.torso.VitalityMult;
        if(equipment.boots != null)
            factor *= equipment.boots.VitalityMult;
        if(equipment.weaponLeft != null)
            factor *= equipment.weaponLeft.VitalityMult;
        return factor;

    }

    public int GetEquipmentVitalitySum(){

        int sum = 0;
        if(equipment.head != null)
            sum += equipment.head.VitalityAdd;
        if(equipment.torso != null)
            sum += equipment.torso.VitalityAdd;
        if(equipment.boots != null)
            sum += equipment.boots.VitalityAdd;
        if(equipment.weaponLeft != null)
            sum += equipment.weaponLeft.VitalityAdd;
        return sum;

    }

    public float GetEquipmentArmorMult(){

        float factor = 1;
        if(equipment.head != null)
            factor *= equipment.head.ArmorMult;
        if(equipment.torso != null)
            factor *= equipment.torso.ArmorMult;
        if(equipment.boots != null)
            factor *= equipment.boots.ArmorMult;
        if(equipment.weaponLeft != null)
            factor *= equipment.weaponLeft.ArmorMult;
        return factor;

    }

    public int GetEquipmentArmorSum(){

        int sum = 0;
        if(equipment.head != null)
            sum += equipment.head.ArmorAdd;
        if(equipment.torso != null)
            sum += equipment.torso.ArmorAdd;
        if(equipment.boots != null)
            sum += equipment.boots.ArmorAdd;
        if(equipment.weaponLeft != null)
            sum += equipment.weaponLeft.ArmorAdd;
        return sum;

    }

    public float GetEquipmentStrengthMult(){

        float factor = 1;
        if(equipment.head != null)
            factor *= equipment.head.StrengthMult;
        if(equipment.torso != null)
            factor *= equipment.torso.StrengthMult;
        if(equipment.boots != null)
            factor *= equipment.boots.StrengthMult;
        if(equipment.weaponLeft != null)
            factor *= equipment.weaponLeft.StrengthMult;
        return factor;

    }

    public int GetEquipmentStrengthSum(){

        int sum = 0;
        if(equipment.head != null)
            sum += equipment.head.StrengthAdd;
        if(equipment.torso != null)
            sum += equipment.torso.StrengthAdd;
        if(equipment.boots != null)
            sum += equipment.boots.StrengthAdd;
        if(equipment.weaponLeft != null)
            sum += equipment.weaponLeft.StrengthAdd;
        return sum;

    }

    public float GetEquipmentMagicMult(){

        float factor = 1;
        if(equipment.head != null)
            factor *= equipment.head.MagicMult;
        if(equipment.torso != null)
            factor *= equipment.torso.MagicMult;
        if(equipment.boots != null)
            factor *= equipment.boots.MagicMult;
        if(equipment.weaponLeft != null)
            factor *= equipment.weaponLeft.MagicMult;
        return factor;

    }

    public int GetEquipmentMagicSum(){

        int sum = 0;
        if(equipment.head != null)
            sum += equipment.head.MagicAdd;
        if(equipment.torso != null)
            sum += equipment.torso.MagicAdd;
        if(equipment.boots != null)
            sum += equipment.boots.MagicAdd;
        if(equipment.weaponLeft != null)
            sum += equipment.weaponLeft.MagicAdd;
        return sum;

    }

    public float GetEquipmentManaMult(){

        float factor = 1;
        if(equipment.head != null)
            factor *= equipment.head.ManaMult;
        if(equipment.torso != null)
            factor *= equipment.torso.ManaMult;
        if(equipment.boots != null)
            factor *= equipment.boots.ManaMult;
        if(equipment.weaponLeft != null)
            factor *= equipment.weaponLeft.ManaMult;
        return factor;

    }

    public int GetEquipmentManaSum(){

        int sum = 0;
        if(equipment.head != null)
            sum += equipment.head.ManaAdd;
        if(equipment.torso != null)
            sum += equipment.torso.ManaAdd;
        if(equipment.boots != null)
            sum += equipment.boots.ManaAdd;
        if(equipment.weaponLeft != null)
            sum += equipment.weaponLeft.ManaAdd;
        return sum;

    }

}