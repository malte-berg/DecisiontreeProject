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

            // case typeof(Head):
            //     print("Equipped head");
            //     head = target as Head;
            //     return true;
            // case typeof(Torso):
            //     print("Equipped torso");
            //     torso = target as Torso;
            //     return true;
            // case typeof(Boots):
            //     print("Equipped boots");
            //     boots = target as Boots;
            //     return true;
            // case typeof(Weapon):
            //     print("Equipped weapon");
            //     weaponLeft = target as Weapon;
            //     return true;
            // case typeof(Consumable):
            //     print("Equipped consumable");
            //     consumableLeft = target as Consumable;
            //     return true;
            default:
                return false;

        }

    }
    
}
