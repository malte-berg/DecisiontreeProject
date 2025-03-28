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

        switch(target.GetType()){

            case Type headType when headType == typeof(Head):
                print("Equipped head");
                head = target as Head;
                return true;
            case Type torsoType when torsoType == typeof(Torso):
                print("Equipped torso");
                torso = target as Torso;
                return true;
            case Type bootsType when bootsType == typeof(Boots):
                print("Equipped boots");
                boots = target as Boots;
                return true;
            case Type weaponType when weaponType == typeof(Weapon):
                print("Equipped weapon");
                weaponLeft = target as Weapon;
                return true;
            case Type consumableType when consumableType == typeof(Consumable):
                print("Equipped consumable");
                consumableLeft = target as Consumable;
                return true;
            default:
                return false;

        }

    }

    /* public bool Unequip(Item target){

        switch(target.GetType()){

            case Type headType when headType == typeof(Head):
                print("Unequipped head");
                head = null;
                return true;
            case typeof(Torso):
                print("Unequipped torso");
                torso = null;
                return true;
            case typeof(Boots):
                print("Unequipped boots");
                boots = null;
                return true;
            case typeof(Weapon):
                print("Unequipped weapon");
                weaponLeft = null;
                return true;
            case typeof(Consumable):
                print("Unequipped consumable");
                consumableLeft = null;
                return true;
            default:
                return false;

        }

    } */
    
}
