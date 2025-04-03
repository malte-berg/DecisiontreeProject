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
            if (s.GetType() == typeof(Punch)){
                s.UpgradeSkill();
                Debug.Log("Upgraded Punch!");
                return;
            }
        }

        Punch punch = new Punch(player);
        punch.UnlockSkill(); 
        player.AddSkill(punch);
        player.AddUnlockedSkill(punch);

        Debug.Log(player.Skills);
    }

    public void SetPointCounter() {
        int points = player.SkillPoints;

        transform.GetChild(13).GetComponent<TMP_Text>().text = $"{points}";
    }
}
