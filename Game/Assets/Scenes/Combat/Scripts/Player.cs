using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter
{

    // PLAYER STATS
    int gold;           //For buying items in the store window.
    int skillPoints;    //For unlocking new abilities in the skill tree window.
    int statPoints;     //For increasing stats in the stats window.
    public int StatPoints { get { return statPoints; } set { this.statPoints = value; } }
    public int SkillPoints { get { return skillPoints; } set { this.skillPoints = value; } }
    public int Gold { get { return gold; } set { this.gold = value; } }

    public Player() : base(

        cName: "Ynnos",
        vitality: 100,
        armor: 0,
        strength: 10,
        magic: 0,
        mana: 0,
        maxSkill: 8,
        inventorySize: 20

    )
    {

        gold = 1750;
        skillPoints = 10;
        statPoints = 25;

    }

    public override void Init()
    {

        sprites = new List<Sprite> { Resources.Load<Sprite>("Sprites/Characters/player1"), Resources.Load<Sprite>("Sprites/Characters/player2") };

        SetSprite("Player");

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        HidePlayer();
        DontDestroyOnLoad(gameObject);

        Skill punch = new Punch(this);
        punch.UnlockSkill();
        AddSkill(punch);

        Skill MindControl = new MindControl(this);
        MindControl.UnlockSkill();
        AddSkill(MindControl);

        // OP dev privilege
        inventory[0] = new Knife();
        inventory[1] = new Pipe();

    }

    //Hide the player model.
    public void HidePlayer()
    {

        transform.GetChild(0).gameObject.SetActive(false);

    }

    //Show the player model.
    public void ShowPlayer()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        SetSprite("Player");

    }

    //Update the player stats (permanently).
    public void UpdateStats(int newVitality, int newStrength, int newMagic, int newStatPoints)
    {
        Vitality = newVitality;
        Strength = newStrength;
        Magic = newMagic;
        statPoints = newStatPoints;
    }
}
