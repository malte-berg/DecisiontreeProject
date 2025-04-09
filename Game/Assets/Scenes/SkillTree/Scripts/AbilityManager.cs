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
    public void HandleSkillClick(Skill skill) {

        if (skill == null) {

            Debug.Log("Skill not found");
            return;

        }

        if (player.SkillPoints < skill.skillCost) {

            Debug.Log("Not enough skill points!");
            return;

        }

        if (skill.unlocked) {

            skill.UpgradeSkill();
            player.SkillPoints -= skill.skillCost;
            // TODO: IMPLEMENT UPDATING SKILL COST HERE
            Debug.Log($"Upgraded {skill.Name}!");

        } else {

            skill.UnlockSkill();
            player.AddSkill(skill);
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Unlocked {skill.Name}!");

        }

        SetPointCounter();

    }

    public void SetPointCounter() {
        int points = player.SkillPoints;

        transform.GetChild(5).GetComponent<TMP_Text>().text = $"{points}"; // TODO: Kan man göra det här snyggare?
    }
}
