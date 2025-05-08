
using UnityEngine;

public class MageHat : Head{
    public MageHat() : base(
        
        icon: Resources.Load<Sprite>("Sprites/Icons/mageHat_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/mageHat"),
        name: "Mage Hat",
        value: 2,
        description: "Now you just need a wand",
        vitalityAdd: 1,
        vitalityMult: 1f,
        armorAdd: 7,
        armorMult: 1f,
        strengthAdd: -2,
        strengthMult: 0.9f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}