using System;
using System.Collections.Generic;
using System.Linq;
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
    public int[] CombatsArr{ get{return combatsWon;}}
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
        expToNextLevel = 6;
    }
    
    public override void Init(){

        if(seed == 0){
            System.Random random = new System.Random();
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            seed = BitConverter.ToInt64(buffer, 0);
        }

        sprites = new List<Sprite> {Resources.Load<Sprite>("Sprites/Characters/player1"), Resources.Load<Sprite>("Sprites/Characters/player2")};

        SetSprite();

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        HidePlayer();
        DontDestroyOnLoad(gameObject);
        
        StartCoroutine(FixBars());
    }
    
    public override bool IsPlayer()
    {
        return true; 
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

            StatPoints += 5;      // Reward stat points for every new level reached
            SkillPoints += 1;     // Reward skill points for every new level reached
            MaxMana = 10 * currentLevel;
        }
    }

    public Save CreateSave(){

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

        Save s = new Save(seed, currentLevel, currentExp, gold, skillPoints, currentAreaIndex, combatsWon, statPoints, stats, equipped, items, levels, selected, unlocked);
        return s;

    }

    public void LoadPlayer(Save save){

        if(save.version != Save.latestVersion){

            Debug.LogError("Wrong save version");
            return;

        }

        seed = save.seed;
        currentLevel = save.level;
        currentExp = save.xp;
        ExpToNextLevel = 6;
        for(int i = 0; i < currentLevel; i++)
            ExpToNextLevel += (int)Mathf.Sqrt(ExpToNextLevel);
        gold = save.gold;
        skillPoints = save.skillPoints;
        currentAreaIndex = save.area;
        combatsWon = save.combats; // this might be an issue due to save instance instead of player instance of arrays
        statPoints = save.statPoints;
        Vitality = save.stats[0];
        Armor = save.stats[1];
        Strength = save.stats[2];
        Magic = save.stats[3];
        Mana = save.stats[4];
        MaxMana = save.stats[4];

        for(int i = 0; i < save.inventory.Length; i++){

            Type type = Type.GetType(save.inventory[i]);
            inventory[i] = (Item)Activator.CreateInstance(type);

            if(save.equipped.Contains(i))
                equipment.Equip(inventory[i]);

        }

        unlockedSkills = new List<Skill>();

        for(int i = 0; i < save.skills.Length; i++){

            Type type = Type.GetType(save.skills[i]);
            Skill tSkill = (Skill)Activator.CreateInstance(type);
            tSkill.UnlockSkill(this);
            tSkill.UpgradeSkill(save.levels[i] - 1);
            AddSkill(tSkill);

        }

        skills = new Skill[save.selected.Length];

        for(int i = 0; i < save.selected.Length; i++){

            if(save.selected[i] == -1)
                break;

            skills[i] = unlockedSkills[save.selected[i]];

        }

    }

}
