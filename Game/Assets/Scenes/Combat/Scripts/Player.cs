using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : GameCharacter {

    // PLAYER STATS
    int gold;                   //For buying items in the store window.
    int skillPoints;            //For unlocking new abilities in the skill tree window.
    int statPoints;             //For increasing stats in the stats window.
    int currentAreaIndex;       //For record the current area of ​​the role
    int currentLevel;
    int currentExp;
    int expToNextLevel;
    int cutscene = -1;          // For telling cutscene scene to run animation

    public int StatPoints{get { return statPoints; } set{ this.statPoints = value; }}
    public int SkillPoints { get { return skillPoints; } set {this.skillPoints = value; }}
    public int Gold{ get{ return gold; } set{ this.gold = value; }}
    public int CurrentAreaIndex{ get{ return currentAreaIndex; } set{ this.currentAreaIndex = value; }}
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
        currentLevel = 0;
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

        Save s = new Save(currentLevel, currentExp, gold, skillPoints, currentAreaIndex, new int[0], new int[0], new Type[0], new int[0], new Type[0]);
        return s;

    }

}
