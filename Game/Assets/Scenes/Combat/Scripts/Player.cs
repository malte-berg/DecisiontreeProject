using UnityEngine;

public class Player : GameCharacter {

    // PLAYER STATS
    int gold;
    int skillPoints;
    int statPoints;
    public int StatPoints{get { return statPoints; } set{ this.statPoints = value; }}

    Skill[] unlockedSkills;

    public int SkillPoints { get { return skillPoints; } set {this.skillPoints = value; }}

    public Skill[] UnlockedSkills { get { return unlockedSkills; }}

    public Player() : base(){

    }

    public override void Init(){

        this.SetSprite("Player");

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        HidePlayer();
        DontDestroyOnLoad(gameObject);

        gold = 10;          //For buying items in the store window.
        skillPoints = 10;    //For unlocking new abilities in the skill tree window.
        statPoints = 25;    //for increasing stats in the stats window.

        skills[0] = new Punch(this);
        skills[0].UnlockSkill();
        unlockedSkills = new Skill[16];
        AddUnlockedSkill(skills[0]);


        // OP dev privilege
        inventory[0] = new Head("Bucket", 2, 0, 1, 7, 1.05f, -2, 1, 0, 1, 0, 1);
        inventory[1] = new Torso("Chainmail", 20, 12, 1.4f, 9, 1.5f, 0, 1, 0, 1, 0, 1);
        inventory[2] = new Boots("Leather Boots", 12, 11, 1.1f, 2, 1.1f, 0, 1, 0, 1, 0, 1);
        inventory[3] = new Weapon("Excalibur", 9999, 10, 1.2f, 5, 1.1f, 224, 10.7f, 23, 1.2f, 162, 1.2f);
        inventory[4] = new Weapon("Wood Sword", 5, 0, 1, 0, 1, 12, 1.1f, 0, 1, 0, 1);
        inventory[5] = new Weapon("Stick", 0, 0, 1, 0, 1, 3, 1, 1, 1, 0, 1);
        inventory[6] = new Head("Helmet", 26, 13, 1.2f, 8, 1.1f, 0, 1, 0, 1, 0, 1);
        inventory[7] = new Torso("Stylish Suit", 170, 50, 1, 5, 1, 5, 1.4f, 15, 1.2f, 10, 1.2f);
        inventory[8] = new Boots("Steel toed boots", 120, 10, 1.2f, 20, 1.35f, 6, 1.1f, 2, 1.05f, 0, 1);

    }
    //Hide the player model.
    public void HidePlayer(){

        transform.GetChild(0).gameObject.SetActive(false);

    }
    
    //Show the player model.
    public void ShowPlayer(){

        transform.GetChild(0).gameObject.SetActive(true);

    }

    public void AddUnlockedSkill(Skill s) {
        for (int i = 0; i < unlockedSkills.Length; i++){
            if (unlockedSkills[i] == null) {
                unlockedSkills[i] = s;
                return;
            }
        }
        Debug.Log("Not enough space!!!");
    }
    
    //Update the player stats (permanently).
    public void UpdateStats(int newVitality, int newStrength, int newMagic, int newStatPoints){
        this.Vitality = newVitality;
        this.Strength = newStrength;
        this.Magic = newMagic;
        this.statPoints = newStatPoints;
    }
}
