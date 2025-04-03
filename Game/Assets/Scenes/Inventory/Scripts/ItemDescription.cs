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

        switch(target.GetType()){

            case Type headType when headType == typeof(Head):
                Head head = target as Head;
                description += $"<color=green>Vitality: \t+{head.VitalityAdd} (+{Mathf.RoundToInt(head.VitalityMult*100)-100}%)</color>\n";
                description += $"<color=orange>Armor: \t+{head.ArmorAdd} (+{Mathf.RoundToInt(head.ArmorMult*100)-100}%)</color>\n";
                description += $"<color=red>Strength: \t+{head.StrengthAdd} (+{Mathf.RoundToInt(head.StrengthMult*100)-100}%)</color>\n";
                description += $"<color=blue>Magic: \t+{head.MagicAdd} (+{Mathf.RoundToInt(head.MagicMult*100)-100}%)</color>\n";
                description += $"<color=purple>Mana: \t+{head.ManaAdd} (+{Mathf.RoundToInt(head.ManaMult*100)-100}%)</color>\n";
                break;
            case Type torsoType when torsoType == typeof(Torso):
                Torso torso = target as Torso;
                description += $"<color=green>Vitality: \t+{torso.VitalityAdd} (+{Mathf.RoundToInt(torso.VitalityMult*100)-100}%)</color>\n";
                description += $"<color=orange>Armor: \t+{torso.ArmorAdd} (+{Mathf.RoundToInt(torso.ArmorMult*100)-100}%)</color>\n";
                description += $"<color=red>Strength: \t+{torso.StrengthAdd} (+{Mathf.RoundToInt(torso.StrengthMult*100)-100}%)</color>\n";
                description += $"<color=blue>Magic: \t+{torso.MagicAdd} (+{Mathf.RoundToInt(torso.MagicMult*100)-100}%)</color>\n";
                description += $"<color=purple>Mana: \t+{torso.ManaAdd} (+{Mathf.RoundToInt(torso.ManaMult*100)-100}%)</color>\n";
                break;
            case Type bootsType when bootsType == typeof(Boots):
                Boots boots = target as Boots;
                description += $"<color=green>Vitality: \t+{boots.VitalityAdd} (+{Mathf.RoundToInt(boots.VitalityMult*100)-100}%)</color>\n";
                description += $"<color=orange>Armor: \t+{boots.ArmorAdd} (+{Mathf.RoundToInt(boots.ArmorMult*100)-100}%)</color>\n";
                description += $"<color=red>Strength: \t+{boots.StrengthAdd} (+{Mathf.RoundToInt(boots.StrengthMult*100)-100}%)</color>\n";
                description += $"<color=blue>Magic: \t+{boots.MagicAdd} (+{Mathf.RoundToInt(boots.MagicMult*100)-100}%)</color>\n";
                description += $"<color=purple>Mana: \t+{boots.ManaAdd} (+{Mathf.RoundToInt(boots.ManaMult*100)-100}%)</color>\n";
                break;
            case Type weaponType when weaponType == typeof(Weapon):
                Weapon weapon = target as Weapon;
                description += $"<color=green>Vitality: \t+{weapon.VitalityAdd} (+{Mathf.RoundToInt(weapon.VitalityMult*100)-100}%)</color>\n";
                description += $"<color=orange>Armor: \t+{weapon.ArmorAdd} (+{Mathf.RoundToInt(weapon.ArmorMult*100)-100}%)</color>\n";
                description += $"<color=red>Strength: \t+{weapon.StrengthAdd} (+{Mathf.RoundToInt(weapon.StrengthMult*100)-100}%)</color>\n";
                description += $"<color=blue>Magic: \t+{weapon.MagicAdd} (+{Mathf.RoundToInt(weapon.MagicMult*100)-100}%)</color>\n";
                description += $"<color=purple>Mana: \t+{weapon.ManaAdd} (+{Mathf.RoundToInt(weapon.ManaMult*100)-100}%)</color>\n";
                break;
            case Type consumableType when consumableType == typeof(Consumable):
                break;
            default:
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
