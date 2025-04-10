using System;
using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour{

    InventoryManager im;
    GameObject slide;
    Item currentDisplay;

    public void Init(InventoryManager im){

        this.im = im;
        slide = transform.GetChild(1).gameObject;
        slide.SetActive(false);

    }

    public void DisplayItem(Item target){

        slide.transform.GetChild(2).GetComponent<TMP_Text>().text = target.Name;
        string description = "";

        switch(target){

            case Head:
                Head head = target as Head;
                description += $"<color=green>Vitality: \t+{head.VitalityAdd} (+{head.VitalityMult*100-100:F1}%)</color>\n";
                description += $"<color=orange>Armor: \t+{head.ArmorAdd} (+{head.ArmorMult*100-100:F1}%)</color>\n";
                description += $"<color=red>Strength: \t+{head.StrengthAdd} (+{head.StrengthMult*100-100:F1}%)</color>\n";
                description += $"<color=blue>Magic: \t+{head.MagicAdd} (+{head.MagicMult*100-100:F1}%)</color>\n";
                description += $"<color=purple>Mana: \t+{head.ManaAdd} (+{head.ManaMult*100-100:F1}%)</color>\n";
                break;
            case Torso:
                Torso torso = target as Torso;
                description += $"<color=green>Vitality: \t+{torso.VitalityAdd} (+{torso.VitalityMult*100-100:F1}%)</color>\n";
                description += $"<color=orange>Armor: \t+{torso.ArmorAdd} (+{torso.ArmorMult*100-100:F1}%)</color>\n";
                description += $"<color=red>Strength: \t+{torso.StrengthAdd} (+{torso.StrengthMult*100-100:F1}%)</color>\n";
                description += $"<color=blue>Magic: \t+{torso.MagicAdd} (+{torso.MagicMult*100-100:F1}%)</color>\n";
                description += $"<color=purple>Mana: \t+{torso.ManaAdd} (+{torso.ManaMult*100-100:F1}%)</color>\n";
                break;
            case Boots:
                Boots boots = target as Boots;
                description += $"<color=green>Vitality: \t+{boots.VitalityAdd} (+{boots.VitalityMult*100-100:F1}%)</color>\n";
                description += $"<color=orange>Armor: \t+{boots.ArmorAdd} (+{boots.ArmorMult*100-100:F1}%)</color>\n";
                description += $"<color=red>Strength: \t+{boots.StrengthAdd} (+{boots.StrengthMult*100-100:F1}%)</color>\n";
                description += $"<color=blue>Magic: \t+{boots.MagicAdd} (+{boots.MagicMult*100-100:F1}%)</color>\n";
                description += $"<color=purple>Mana: \t+{boots.ManaAdd} (+{boots.ManaMult*100-100:F1}%)</color>\n";
                break;
            case Weapon:
                Weapon weapon = target as Weapon;
                description += $"<color=green>Vitality: \t+{weapon.VitalityAdd} (+{weapon.VitalityMult*100-100:F1}%)</color>\n";
                description += $"<color=orange>Armor: \t+{weapon.ArmorAdd} (+{weapon.ArmorMult*100-100:F1}%)</color>\n";
                description += $"<color=red>Strength: \t+{weapon.StrengthAdd} (+{weapon.StrengthMult*100-100:F1}%)</color>\n";
                description += $"<color=blue>Magic: \t+{weapon.MagicAdd} (+{weapon.MagicMult*100-100:F1}%)</color>\n";
                description += $"<color=purple>Mana: \t+{weapon.ManaAdd} (+{weapon.ManaMult*100-100:F1}%)</color>\n";
                break;
            case Consumable:
                // TODO
                break;
            default:
                Debug.LogError("No item type found");
                break;

        }

        slide.transform.GetChild(1).GetComponent<TMP_Text>().text = description;
        currentDisplay = target;
        
        slide.SetActive(true);

    }

    public void Equip(){

        if(currentDisplay == null)
            return;

        im.player.equipment.Equip(currentDisplay);
        im.sl.UpdateStats();

    }

}
