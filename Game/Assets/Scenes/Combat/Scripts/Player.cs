using UnityEngine;

public class Player : GameCharacter {

    // PLAYER STATS
    int gold;
    int skillPoints;

    Skill[] unlockedSkills;

    public int SkillPoints { get { return skillPoints; }}

    public Skill[] UnlockedSkills { get { return unlockedSkills; }}

    public Player() : base(){

    }

    public override void Init(){

        equipment = gameObject.GetComponent<Equipment>();
        gameObject.name = "Player";
        DontDestroyOnLoad(gameObject);

        int gold = 10;
        int skillPoints = 0;

        skills[0] = new Punch(this);
        skills[0].UnlockSkill();
        unlockedSkills = new Skill[16];
        AddUnlockedSkill(skills[0]);


        // OP dev privilege
        inventory[0] = new Weapon("Excalibur", 9999, 10, 1.2f, 5, 1.1f, 224, 10.7f, 23, 1.2f, 162, 1.2f);
        equipment.Equip(inventory[0]);

    }

    public void HidePlayer(){

        transform.GetChild(0).gameObject.SetActive(false);

    }

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
    
}
