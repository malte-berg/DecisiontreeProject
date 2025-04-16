using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsHandler : MonoBehaviour {

    int vitalityIncrease = 0;
    int strengthIncrease = 0;
    int magicIncrease = 0;
    int statPoints;
    public TextMeshProUGUI vitalityText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI magicText;
    public TextMeshProUGUI statPointsText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public Image expBar;
    public Player player;
    
    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>(); //horrible way of doing this (TAGET FRÅN Combat.cs)
        this.statPoints = player.StatPoints;    //Get player's current amount of stat points.
        DisplayStatText(); //Make sure the stat texts show the correct player stats.
    }

    //Changes the text in the stat windows to show the correct player stats
    public void DisplayStatText(){
        vitalityText.text = "<color=green>Vitality:\t" + player.Vitality + "\t+" + vitalityIncrease +"</color>";
        strengthText.text = "<color=red>Strength:\t" + player.Strength + "\t+" + strengthIncrease + "</color>";
        magicText.text = "<color=blue>Magic:\t" + player.Magic + "\t+" + magicIncrease + "</color>";
        statPointsText.text = "Stat Points: " + statPoints;
        print(expText);
        expText.text = $"EXP: {player.CurrentExp}/{player.ExpToNextLevel}";
        levelText.text = $"Level: {player.CurrentLevel}";

        expBar.fillAmount = (float)player.CurrentExp / player.ExpToNextLevel; // Used for the Exp level bar
    }

    //Update the player stats and show the new stats.
    public void UpdateStats(){

        player.UpdateStats(vitalityIncrease, strengthIncrease, magicIncrease);
        player.StatPoints = statPoints;
        vitalityIncrease = 0; strengthIncrease = 0; magicIncrease = 0;  //Set "+ [number]" to "+ 0" again.
        DisplayStatText();  //Change the stat texts in the windows again.
        
    }

    public void IncreaseStat(string stat){
        //Öka numret i texten för rätt stat.
        //Öka "strengthIncrease" eller annat..
        if(statPoints > 0) {
            switch (stat) {
                case "Vitality":
                    vitalityIncrease++;
                    break;
                case "Strength":
                    strengthIncrease++;
                    break;
                case "Magic":
                    magicIncrease++;
                    break;
                default:
                    print("brokie");
                    break;
            }
            
            statPoints--;
            DisplayStatText();
        }
    }

    public void DecreaseStat(string stat){
        switch (stat) {
            case "Vitality":
                if(vitalityIncrease > 0) {
                    vitalityIncrease--; 
                    statPoints++; 
                }
                break;
            case "Strength":
                if(strengthIncrease > 0) {
                    strengthIncrease--;
                    statPoints++;
                }
                break;
            case "Magic":
                if(magicIncrease > 0) {
                    magicIncrease--;
                    statPoints++;
                }
                break;
        }
        
        DisplayStatText();
    }
}
