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

    public void HandleClickPunch() {
        if (player.SkillPoints <= 0){
            Debug.Log("Not enough skill points!");
            return;
        }

        foreach (Skill s in player.UnlockedSkills){
            if (s is Punch){
                s.UpgradeSkill();
                player.SkillPoints = player.SkillPoints - 1;
                SetPointCounter();
                Debug.Log("Upgraded Punch!");
                return;
            }
        }

        Punch punch = new Punch(player);
        punch.UnlockSkill(); 
        player.AddSkill(punch);
        player.AddUnlockedSkill(punch);
        player.SkillPoints = player.SkillPoints - 1;
                SetPointCounter();

        Debug.Log(player.Skills);
    }

    public void HandleClickHeatWave() {
        if (player.SkillPoints <= 0){
            Debug.Log("Not enough skill points!");
            return;
        }

        foreach (Skill s in player.UnlockedSkills){
            if (s is HeatWave){
                s.UpgradeSkill();
                player.SkillPoints = player.SkillPoints - 1;
                SetPointCounter();
                Debug.Log("Upgraded Heat Wave!");
                return;
            }
        }

        foreach (Skill s in player.UnlockedSkills){
            if (s is Punch){
                HeatWave heatWave = new HeatWave(player);
                heatWave.UnlockSkill();
                player.AddSkill(heatWave);
                player.AddUnlockedSkill(heatWave);
                player.SkillPoints = player.SkillPoints - 1;
                SetPointCounter();
                Debug.Log("Unlocked Heat Wave!");
                return;
            }
        }
    }

    public void HandleClickHeal() {
        if (player.SkillPoints <= 0){
            Debug.Log("Not enough skill points!");
        }
    }

    public void SetPointCounter() {
        int points = player.SkillPoints;

        transform.GetChild(6).GetComponent<TMP_Text>().text = $"{points}";
    }
}
