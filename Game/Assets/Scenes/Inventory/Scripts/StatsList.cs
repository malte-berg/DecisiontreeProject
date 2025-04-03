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
        if(im.player.equipment.weaponLeft != null)
            text += $"<size=70%><color=black>Weapon: \t{im.player.equipment.weaponLeft.Name}\n";
        else text += "<size=70%><color=black>Weapon: \tN/A\n";
        if(im.player.equipment.head != null)
            text += $"Head: \t{im.player.equipment.head.Name}\n";
        else text += "Head: \tN/A\n";
        if(im.player.equipment.torso != null)
            text += $"Torso: \t{im.player.equipment.torso.Name}\n";
        else text += "Torso: \tN/A\n";
        if(im.player.equipment.boots != null)
            text += $"Boots: \t{im.player.equipment.boots.Name}</color></size>\n";
        else text += "Boots: \tN/A</color></size>\n";
        text += $"<color=green>Vitality: \t{im.player.Vitality}</color>\n";
        text += $"<color=orange>Armor: \t{im.player.Armor}</color>\n";
        text += $"<color=red>Strength: \t{im.player.Strength}</color>\n";
        text += $"<color=blue>Magic: \t{im.player.Magic}</color>\n";
        text += $"<color=purple>Mana: \t{im.player.Mana}</color>\n";

        statText.text = text;

    }

}
