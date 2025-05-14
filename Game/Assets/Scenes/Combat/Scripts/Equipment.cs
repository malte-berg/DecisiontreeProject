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
                if(target == head) head = null;
                else head = target as Head;
                return true;
            case Torso:
                if(target == torso) torso = null;
                else torso = target as Torso;
                return true;
            case Boots:
                if(target == boots) boots = null;
                else boots = target as Boots;
                return true;
            case Weapon:
                if(target == weaponLeft) weaponLeft = null;
                else weaponLeft = target as Weapon;
                return true;
            case Consumable:
                if(target == consumableLeft) consumableLeft = null;
                else consumableLeft = target as Consumable;
                return true;
            default:
                return false;

        }

    }

    public void PrintEquipment(){

        print($@"{gameObject?.name} equipment:
        HEAD:           {head?.Name}
        TORSO:          {torso?.Name}
        BOOTS:          {boots?.Name}
        WEAPON-L:       {weaponLeft?.Name}
        WEAPON-R:       {weaponRight?.Name}
        CONSUMABLE-L:   {consumableLeft?.Name}
        CONSUMABLE-R:   {consumableRight?.Name}");

    }
    
}
