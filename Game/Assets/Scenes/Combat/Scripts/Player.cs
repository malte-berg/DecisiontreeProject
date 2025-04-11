using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter {

    // PLAYER STATS
    int gold;           //For buying items in the store window.
    int skillPoints;    //For unlocking new abilities in the skill tree window.
    int statPoints;     //For increasing stats in the stats window.
    int currentAreaIndex; //For record the current area of ​​the role

    public int StatPoints{get { return statPoints; } set{ this.statPoints = value; }}
    public int SkillPoints { get { return skillPoints; } set {this.skillPoints = value; }}
    public int Gold{ get{ return gold; } set{ this.gold = value; }}
    public int CurrentAreaIndex{ get{ return currentAreaIndex; } set{ this.currentAreaIndex = value; }}

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
      
        inventory = AreaDataLoader.GetAreaItems(currentAreaIndex);

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

}
