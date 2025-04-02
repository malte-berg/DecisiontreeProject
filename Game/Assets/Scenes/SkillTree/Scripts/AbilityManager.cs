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

    public void handleClickPunch(){

    }

    public void SetPointCounter() {
        // int points = player.SkillPoints;
        int points = 100;

        transform.GetChild(13).GetComponent<TMP_Text>().text = $"{points}";
    }
}
