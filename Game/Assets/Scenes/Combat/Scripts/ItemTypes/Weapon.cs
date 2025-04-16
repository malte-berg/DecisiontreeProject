using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item{

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

    public Weapon(Sprite icon, List<Sprite> sprites, string name, int value, string description, int vitalityAdd, float vitalityMult, int armorAdd, float armorMult, int strengthAdd, float strengthMult, int magicAdd, float magicMult, int manaAdd, float manaMult) : base(name, value, description){

        this.icon = icon;
        this.sprites = sprites;
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
}
