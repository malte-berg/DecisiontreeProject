using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour {
    public Player player;
    
    public void Init(){
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();
    }

    void Awake(){

        Init();

    }

    public bool HandleSkill(Skill skill) {
        if (skill == null) {
            Debug.Log("Skill not found");
            return false;
        }

        if (player.SkillPoints < skill.skillCost) {
            Debug.Log("Not enough skill points!");
            return false;
        }

        if (skill.unlocked) {
            skill.UpgradeSkill();
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Upgraded {skill.Name}!");
            return true;
        }

        skill.UnlockSkill();
        player.AddSkill(skill);
        player.SkillPoints -= skill.skillCost;
        Debug.Log($"Unlocked {skill.Name}!");
        return true;
    }
}
