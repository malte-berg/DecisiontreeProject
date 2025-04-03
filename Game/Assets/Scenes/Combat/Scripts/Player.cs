using UnityEngine;

public class Player : GameCharacter {

    // PLAYER STATS
    int gold;
    int skillPoints;
    int statPoints;
    public int StatPoints{get { return statPoints; } set{ this.statPoints = value; }}

    public Player() : base(){

    }

    public override void Init(){

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        DontDestroyOnLoad(gameObject);

        int gold = 10;          //For buying items in the store window.
        int skillPoints = 0;    //For unlocking new abilities in the skill tree window.
        statPoints = 25;    //for increasing stats in the stats window.

        skills[0] = new Punch(this);

        // OP dev privilege
        inventory[0] = new Weapon("Excalibur", 9999, 10, 1.2f, 5, 1.1f, 224, 10.7f, 23, 1.2f, 162, 1.2f);
        equipment.Equip(inventory[0]);

    }
    //Hide the player model.
    public void HidePlayer(){

        transform.GetChild(0).gameObject.SetActive(false);

    }
    
    //Show the player model.
    public void ShowPlayer(){

        transform.GetChild(0).gameObject.SetActive(true);

    }
    
    //Update the player stats (permanently).
    public void UpdateStats(int newVitality, int newStrength, int newMagic, int newStatPoints){
        this.Vitality = newVitality;
        this.Strength = newStrength;
        this.Magic = newMagic;
        this.statPoints = newStatPoints;
    }
}
