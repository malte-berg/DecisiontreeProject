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

            case Type thisType when thisType == typeof(Head) || thisType == typeof(Torso) || thisType == typeof(Boots) || thisType == typeof(Weapon):
                Head tC = target as Head;
                description += $"<color=green>Vitality: \t+{tC.VitalityAdd} (+{Mathf.RoundToInt(tC.VitalityMult*100)-100}%)</color>\n";
                description += $"<color=orange>Armor: \t+{tC.ArmorAdd} (+{Mathf.RoundToInt(tC.ArmorMult*100)-100}%)</color>\n";
                description += $"<color=red>Strength: \t+{tC.StrengthAdd} (+{Mathf.RoundToInt(tC.StrengthMult*100)-100}%)</color>\n";
                description += $"<color=blue>Magic: \t+{tC.MagicAdd} (+{Mathf.RoundToInt(tC.MagicMult*100)-100}%)</color>\n";
                description += $"<color=purple>Mana: \t+{tC.ManaAdd} (+{Mathf.RoundToInt(tC.ManaMult*100)-100}%)</color>\n";
                break;
            default:
                break;

        }

        slide.transform.GetChild(1).GetComponent<TMP_Text>().text = description;
        currentDisplay = target;
        
        slide.SetActive(true);

    }

}
