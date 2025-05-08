using UnityEngine;

public class MageHat : Head{
    public MageHat() : base(
        
        icon: Resources.Load<Sprite>("Sprites/Icons/mageHat_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/mageHat"),
        name: "Mage Hat",
        value: 40,
        description: "Now you just need a wand",
        vitalityAdd: 5,
        vitalityMult: 1f,
        armorAdd: 3,
        armorMult: 1f,
        strengthAdd: 0,
        strengthMult: 0.9f,
        magicAdd: 8,
        magicMult: 1f,
        manaAdd: 20,
        manaMult: 1f
        
    ) {
        
    }

}