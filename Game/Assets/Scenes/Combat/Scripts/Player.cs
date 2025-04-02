using UnityEngine;

public class Player : GameCharacter {

    Combat c;

    // STATS
    int hp;
    int vitality;
    int armor;
    int strength;
    int magic;
    int mana;
    int maxMana;

    // SKILL
    public Skill[] skills;
    int skillCount;
    int selectedSkill = 0;

    // INVENTORY
    Equipment equipment;
    Item[] inventory;

    // PLAYER STATS
    int gold;
    int skillPoints;

    // public Player() : base(hp, vitality, armor, strength, magic, mana, maxMana, skills, skillCount, equipment, inventory){

    //     int gold = 10;
    //     int skillPoints = 0;

    // }
    
}
