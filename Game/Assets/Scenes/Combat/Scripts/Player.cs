using UnityEngine;

public class Player : GameCharacter {

    // PLAYER STATS
    int gold;
    int skillPoints;

    public Player() : base(){

    }

    public override void Init(){

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        HidePlayer();
        DontDestroyOnLoad(gameObject);

        int gold = 10;
        int skillPoints = 0;

        skills[0] = new Punch(this);

        // OP dev privilege
        inventory[0] = new Weapon("Excalibur", 9999, 10, 1.2f, 5, 1.1f, 224, 10.7f, 23, 1.2f, 162, 1.2f);
        // equipment.Equip(inventory[0]);

    }

    public void HidePlayer(){

        transform.GetChild(0).gameObject.SetActive(false);

    }

    public void ShowPlayer(){

        transform.GetChild(0).gameObject.SetActive(true);

    }
    
}
