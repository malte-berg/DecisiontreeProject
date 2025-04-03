using UnityEngine;

public class Head : Item {

    string name;
    int value;

    int vitalityAdd;
    float vitalityMult;
    public int VitalityAdd{ get{ return vitalityAdd; } }
    public float VitalityMult{ get{ return vitalityMult; } }

    int armorAdd;
    float armorMult;
    public int ArmorAdd{ get{ return armorAdd; } }
    public float ArmorMult{ get{ return armorMult; } }
    
    int strengthAdd;
    float strengthMult;
    public int StrengthAdd{ get{ return strengthAdd; } }
    public float StrengthMult{ get{ return strengthMult; } }

    int magicAdd;
    float magicMult;
    public int MagicAdd{ get{ return magicAdd; } }
    public float MagicMult{ get{ return magicMult; } }
    
    int manaAdd;
    float manaMult;
    public int ManaAdd{ get{ return manaAdd; } }
    public float ManaMult{ get{ return manaMult; } }

    public Head(string name, int value) : this(name, value, 0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f){}

    public Head(string name, int value, int vitalityAdd, float vitalityMult, int armorAdd, float armorMult, int strengthAdd, float strengthMult, int magicAdd, float magicMult, int manaAdd, float manaMult) : base(name, value){

        this.name = name;
        this.value = value;
        this.vitalityAdd = vitalityAdd;
        this.vitalityMult = vitalityMult;
        this.armorAdd = armorAdd;
        this.armorMult = armorMult;
        this.strengthAdd = strengthAdd;
        this.strengthMult = strengthMult;
        this.magicAdd = magicAdd;
        this.magicMult = magicMult;
        this.manaAdd = manaAdd;
        this.manaMult = manaMult;

    }

    public override string GetNamn(){
        return this.name;
    }
    public override int GetValue(){
        return this.value;
    }  
}
