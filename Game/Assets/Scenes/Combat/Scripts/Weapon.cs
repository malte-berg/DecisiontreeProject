using UnityEngine;

public class Weapon : Item{

    string name;
    int value;
    int strengthAdd;
    float strengthMult;
    int vitalityAdd;
    float vitalityMult;
    int magicAdd;
    float magicMult;
    int armorAdd;
    float armorMult;
    int manaAdd;
    float manaMult;

    public Weapon(string name, int value, int vitalityAdd, float vitalityMult, int armorAdd, float armorMult, int strengthAdd, float strengthMult, int magicAdd, float magicMult, int manaAdd, float manaMult) : base(name, value){

        this.name = name;
        this.value = value;
        this.strengthAdd = strengthAdd;
        this.strengthMult = strengthMult;
        this.vitalityAdd = vitalityAdd;
        this.vitalityMult = vitalityMult;
        this.magicAdd = magicAdd;
        this.magicMult = magicMult;
        this.armorAdd = armorAdd;
        this.armorMult = armorMult;
        this.manaAdd = manaAdd;
        this.manaMult = manaMult;

    }

}
