using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour {

    public Player player;
    
    public void Init(){
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();
        SetPointCounter();
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

        if (skill is Punch && player.skills[0] != skill) {
            player.skills[0] = skill;
            Debug.Log("Replaced Punch skill!");
            skill.UpgradeSkill();
            player.SkillPoints -= skill.skillCost;
            SetPointCounter();
            Debug.Log($"Upgraded {skill.Name}!");
            return;
        }

        if (skill.unlocked) {
            skill.UpgradeSkill();
            player.SkillPoints -= skill.skillCost;
            SetPointCounter();
            Debug.Log($"Upgraded {skill.Name}!");
            return;
        }

        skill.UnlockSkill();
        player.AddSkill(skill);
        player.SkillPoints -= skill.skillCost;
        Debug.Log($"Unlocked {skill.Name}!");
        SetPointCounter();
    }

    public void SetPointCounter() {
        int points = player.SkillPoints;

        transform.GetChild(6).GetComponent<TMP_Text>().text = $"{points}";
    }
}
