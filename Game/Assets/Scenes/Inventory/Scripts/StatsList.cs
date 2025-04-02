using TMPro;
using UnityEngine;

public class StatsList : MonoBehaviour {
    
    InventoryManager im;
    TMP_Text statText;

    public void Init(InventoryManager im){

        this.im = im;
        statText = GetComponentInChildren<TMP_Text>();
        UpdateStats();

    }

    public void UpdateStats(){

        string text = "";
        text += $"<color=green>Vitality: \t{im.player.Vitality}</color>\n";
        text += $"<color=orange>Armor: \t{im.player.Armor}</color>\n";
        text += $"<color=red>Strength: \t{im.player.Strength}</color>\n";
        text += $"<color=blue>Magic: \t{im.player.Magic}</color>\n";
        text += $"<color=purple>Mana: \t{im.player.Mana}</color>\n";

        statText.text = text;

    }

}
