using UnityEngine;

public class SteelToedBoots : Boots{

    public SteelToedBoots() : base(

        sprite: Resources.Load<Sprite>("Sprites/Items/steelToedBoots"),
        name: "Steel Toed Boots",
        value: 102,
        description: "To protect you from the annoying kick to the smallest toe, now with protection of steel.",
        vitalityAdd: 55,
        vitalityMult: 1.01f,
        armorAdd: 8,
        armorMult: 1.01f,
        strengthAdd: 2,
        strengthMult: 1.002f,
        magicAdd: 1,
        magicMult: 1.01f,
        manaAdd: 6,
        manaMult: 1f
        
    ) {
        
    }

}