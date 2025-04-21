using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour{

    InventoryManager im;
    GameObject slide;
    Item currentDisplay;
    TMP_Text equipButtonText;

    public void Init(InventoryManager im){

        this.im = im;
        slide = transform.GetChild(1).gameObject;
        slide.SetActive(false);
        equipButtonText = slide.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>();

    }

    public void DisplayItem(Item target){

        slide.transform.GetChild(2).GetComponent<TMP_Text>().text = target.Name;
        string description = "";

        switch(target){

            case Head:
                Head head = target as Head;
                description += $"<color=green>Vitality: \t{CalcAdd(head.VitalityAdd)} ({CalcMult(head.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(head.ArmorAdd)} ({CalcMult(head.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(head.StrengthAdd)} ({CalcMult(head.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(head.MagicAdd)} ({CalcMult(head.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(head.ManaAdd)} ({CalcMult(head.ManaMult)})</color>\n";

                equipButtonText.text = (im.player.equipment.head == head) ? "Unequip" : "Equip";

                break;
            case Torso:
                Torso torso = target as Torso;
                description += $"<color=green>Vitality: \t{CalcAdd(torso.VitalityAdd)} ({CalcMult(torso.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(torso.ArmorAdd)} ({CalcMult(torso.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(torso.StrengthAdd)} ({CalcMult(torso.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(torso.MagicAdd)} ({CalcMult(torso.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(torso.ManaAdd)} ({CalcMult(torso.ManaMult)})</color>\n";

                equipButtonText.text = (im.player.equipment.torso == torso) ? "Unequip" : "Equip";
                break;
            case Boots:
                Boots boots = target as Boots;
                description += $"<color=green>Vitality: \t{CalcAdd(boots.VitalityAdd)} ({CalcMult(boots.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(boots.ArmorAdd)} ({CalcMult(boots.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(boots.StrengthAdd)} ({CalcMult(boots.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(boots.MagicAdd)} ({CalcMult(boots.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(boots.ManaAdd)} ({CalcMult(boots.ManaMult)})</color>\n";

                equipButtonText.text = (im.player.equipment.boots == boots) ? "Unequip" : "Equip";
                break;
            case Weapon:
                Weapon weapon = target as Weapon;
                description += $"<color=green>Vitality: \t{CalcAdd(weapon.VitalityAdd)} ({CalcMult(weapon.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(weapon.ArmorAdd)} ({CalcMult(weapon.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(weapon.StrengthAdd)} ({CalcMult(weapon.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(weapon.MagicAdd)} ({CalcMult(weapon.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(weapon.ManaAdd)} ({CalcMult(weapon.ManaMult)})</color>\n";

                equipButtonText.text = (im.player.equipment.weaponLeft == weapon) ? "Unequip" : "Equip";
                break;
            case Consumable:
                // TODO
                break;
            default:
                Debug.LogError("No item type found");
                break;

        }
        
        description += $"\n<i><size=75%>{target.Description}</size></i>";

        slide.transform.GetChild(0).GetComponent<Image>().sprite = target.icon;
        slide.transform.GetChild(1).GetComponent<TMP_Text>().text = description;
        currentDisplay = target;
        
        slide.SetActive(true);

    }

    private string CalcAdd(int statAdd) {
        return $"{(statAdd < 0 ? "" : "+")}{statAdd}";
    }

    private string CalcMult(float statMult) {
        return $"{(statMult < 1 ? "" : "+")}{statMult*100-100:F1}%";
    }

    public void Equip(){

        if(currentDisplay == null)
            return;

        im.player.equipment.Equip(currentDisplay);

        // Update button
        if (equipButtonText.text == "Equip") {
            equipButtonText.text = "Unequip";
        } else {
            equipButtonText.text = "Equip";
        }

        im.sl.UpdateStats();
        // Update player sprites after equpping/unequipping
        im.player.SM.SetCharacter(im.player);

    }

}
