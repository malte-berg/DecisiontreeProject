using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour {
    private Player player;
    
    public void Init(){
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
    }

    void Awake(){

        Init();

    }

    public void HandleSkill(Skill skill) {
        if (skill == null) {

            Debug.Log("Skill not found");
            return;

        }

        if (player.SkillPoints < skill.skillCost) {

            Debug.Log("Not enough skill points!");
            return;
        }

        Skill playerSkill = GetPlayerSkillByName(skill.Name);

        if (playerSkill == null) {
            skill.UnlockSkill(player);
            player.AddSkill(skill);
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Unlocked {skill.Name}!");
            return;
        }

        if (playerSkill.unlocked) {
            playerSkill.UpgradeSkill();
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Upgraded {skill.Name}!");
            return;

        }

        Debug.Log("Something went wrong!");
        return;
    }
    

    public Skill GetPlayerSkillByName(string name) {
        foreach (Skill skill in player.skills) {
            if (skill == null) {
                continue;
            } else if (skill.Name == name) {
                return skill;
            }
        }
        return null;
    }
}