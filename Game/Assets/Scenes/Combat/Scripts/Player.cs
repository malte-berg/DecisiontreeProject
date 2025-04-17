using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter {

    // GAME STATS
    long seed;
    public long Seed{ get { return seed; }}

    // PLAYER STATS
    int gold;                   //For buying items in the store window.
    int skillPoints;            //For unlocking new abilities in the skill tree window.
    int statPoints;             //For increasing stats in the stats window.
    int currentAreaIndex;       //For record the current area of ​​the role
    int[] combatsWon = new int[4];
    int currentLevel;
    int currentExp;
    int expToNextLevel;
    int cutscene = -1;          // For telling cutscene scene to run animation

    public int StatPoints{get { return statPoints; } set{ this.statPoints = value; }}
    public int SkillPoints { get { return skillPoints; } set {this.skillPoints = value; }}
    public int Gold{ get{ return gold; } set{ this.gold = value; }}
    public int CurrentAreaIndex{ get{ return currentAreaIndex; } set{ this.currentAreaIndex = value; }}
    public int CombatsWon{ get{ return combatsWon[currentAreaIndex]; } set {combatsWon[currentAreaIndex] = value;}}
    public int CurrentLevel { get { return currentLevel; } set { this.currentLevel = value; }}
    public int CurrentExp { get { return currentExp; } set { this.currentExp = value; }}
    public int ExpToNextLevel { get { return expToNextLevel; } set { this.expToNextLevel = value; }}
    public int Cutscene{ get{ return cutscene; }}

    public Player() : base(

        cName: "Ynnos",
        vitality: 100,
        armor: 0,
        strength: 10,
        magic: 0,
        mana: 0,
        maxSkill: 8,
        inventorySize: 20

    ){

        gold = 1750;
        skillPoints = 10;
        statPoints = 25;
        currentAreaIndex = 1; // save index(0) for tutorial Area
        currentLevel = 1;
        currentExp = 0;
        expToNextLevel = 100;
    }
    
    public override void Init(){

        sprites = new List<Sprite> {Resources.Load<Sprite>("Sprites/Characters/player1"), Resources.Load<Sprite>("Sprites/Characters/player2")};

        SetSprite();

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        HidePlayer();
        DontDestroyOnLoad(gameObject);
      
        Skill punch = new Punch();
        punch.UnlockSkill(this);
        AddSkill(punch);

    }
    //Hide the player model.
    public void HidePlayer(){

        transform.GetChild(0).gameObject.SetActive(false);

    }
    
    //Show the player model.
    public void ShowPlayer(){

        transform.GetChild(0).gameObject.SetActive(true);
        SetSprite();

    }
    
    public void AddExp(int amount)
    {
        CurrentExp += amount;

        while (CurrentExp >= ExpToNextLevel)
        {
            CurrentExp -= ExpToNextLevel;
            CurrentLevel++;
            ExpToNextLevel += 50;

            StatPoints += 5;      // Reward stat points for every new level reached
            SkillPoints += 1;     // Reward skill points for every new level reached
        }
    }

    public Save CreateSave(){

        /// TEMP ///
        inventory[0] = new Knife();
        inventory[1] = new BrassKnuckles();
        inventory[2] = new Jacket();
        inventory[3] = new Bucket();
        inventory[4] = new WorkerBoots();
        equipment.Equip(inventory[0]);
        equipment.Equip(inventory[2]);
        equipment.Equip(inventory[3]);
        equipment.Equip(inventory[4]);
        /// TEMP ///

        int[] equipped = new int[7];

        int inventoryCount = 0;
        for(; inventoryCount < inventory.Length && inventory[inventoryCount] != null; ++inventoryCount);
        string[] items = new string[inventoryCount];

        for(int i = 0; i < inventory.Length && inventory[i] != null; i++){

            items[i] = inventory[i].GetType().FullName;

            switch(inventory[i]){

                case Head:
                    if(equipment.head == inventory[i])
                        equipped[0] = i;
                    break;

                case Torso:
                    if(equipment.torso == inventory[i])
                        equipped[1] = i;
                    break;

                case Boots:
                    if(equipment.boots == inventory[i])
                        equipped[2] = i;
                    break;

                case Weapon:
                    if(equipment.weaponLeft == inventory[i])
                        equipped[3] = i;
                    else if(equipment.weaponRight == inventory[i])
                        equipped[4] = i;
                    break;

                case Consumable:
                    if(equipment.consumableLeft == inventory[i])
                        equipped[5] = i;
                    else if(equipment.consumableRight == inventory[i])
                        equipped[6] = i;
                    break;

            }

        }

        string[] unlocked = new string[unlockedSkills.Count];
        int[] selected = new int[skills.Length];

        for(int i = 0; i < selected.Length; i++)
            selected[i] = -1;

        int[] levels = new int[unlockedSkills.Count];

        for(int i = 0; i < unlocked.Length; i++){
            unlocked[i] = unlockedSkills[i].GetType().FullName;
            levels[i] = unlockedSkills[i].SkillLevel;
            for(int ii = 0; ii < skills.Length; ii++){
                if(skills[ii] == unlockedSkills[i])
                    selected[ii] = i;
            }
        }

        int[] stats = GetBaseStats();

        Save s = new Save(currentLevel, currentExp, gold, skillPoints, currentAreaIndex, combatsWon, stats, equipped, items, levels, selected, unlocked);
        return s;

    }

}
