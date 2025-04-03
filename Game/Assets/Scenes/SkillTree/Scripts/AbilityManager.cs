using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour {

    public Player player;

    public Skill[] allSkills;
    
    public void Init(){
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();
        SetPointCounter();

        allSkills = new Skill[16];
        allSkills[1] = new Punch(player);
        allSkills[2] = new HeatWave(player);
        allSkills[3] = new Heal(player);
        allSkills[4] = new Sacrifice(player);
    }

    void Awake(){

        Init();

    }

    public void HandleSkillClick(int index) {
        if (index < 0 || index >= allSkills.Length) {
            Debug.Log("Invalid skill index");
            return;
        }

        Skill skill = allSkills[index];

        if (skill == null) {
            Debug.Log("Skill not found");
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
        player.AddUnlockedSkill(skill);
        player.SkillPoints -= skill.skillCost;
        Debug.Log($"Unlocked {skill.Name}!");
        SetPointCounter();
    }

    public void SetPointCounter() {
        int points = player.SkillPoints;

        transform.GetChild(6).GetComponent<TMP_Text>().text = $"{points}";
    }
}
