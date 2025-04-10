using System;
using UnityEngine;

public class Equipment : MonoBehaviour{

    public Head head;
    public Torso torso;
    public Boots boots;
    public Weapon weaponRight;
    public Weapon weaponLeft;
    public Consumable consumableRight;
    public Consumable consumableLeft;

    public bool Equip(Item target){

        switch(target){

            case Head:
                // print($"{gameObject.name}: Equipped/unequipped head: {target.Name}");
                if(target == head) head = null;
                else head = target as Head;
                return true;
            case Torso:
                // print($"{gameObject.name}: Equipped/unequipped torso: {target.Name}");
                if(target == torso) torso = null;
                else torso = target as Torso;
                return true;
            case Boots:
                // print($"{gameObject.name}: Equipped/unequipped boots: {target.Name}");
                if(target == boots) boots = null;
                else boots = target as Boots;
                return true;
            case Weapon:
                // print($"{gameObject.name}: Equipped/unequipped weapon: {target.Name}");
                if(target == weaponLeft) weaponLeft = null;
                else weaponLeft = target as Weapon;
                return true;
            case Consumable:
                // print($"{gameObject.name}: Equipped/unequipped consumable: {target.Name}");
                if(target == consumableLeft) consumableLeft = null;
                else consumableLeft = target as Consumable;
                return true;
            default:
                return false;

        }

    }
    
}
