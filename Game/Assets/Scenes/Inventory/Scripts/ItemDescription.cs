using System;
using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour{

    InventoryManager im;
    GameObject slide;

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
                description += $"<color=green>Vitality: \t+{tC.VitalityAdd} (+{(tC.VitalityMult*100)-100}%)</color>";
                description += $"<color=orange>Armor: \t+{tC.ArmorAdd} (+{(tC.ArmorMult*100)-100}%)</color>";
                description += $"<color=red>Strength: \t+{tC.StrengthAdd} (+{(tC.StrengthMult*100)-100}%)</color>";
                description += $"<color=blue>Magic: \t+{tC.MagicAdd} (+{(tC.MagicMult*100)-100}%)</color>";
                description += $"<color=purple>Mana: \t+{tC.ManaAdd} (+{(tC.ManaMult*100)-100}%)</color>";
                break;
            default:
                break;

        }

        slide.transform.GetChild(1).GetComponent<TMP_Text>().text = description;
        
        slide.SetActive(true);

    }

}
