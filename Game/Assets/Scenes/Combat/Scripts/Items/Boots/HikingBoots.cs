using UnityEngine;

public class HikingBoots : Boots{

    public HikingBoots() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/hikingBoots_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/hikingBoots"),
        name: "Hiking Boots",
        value: 36,
        description: "Made for the distances, these boots will take you places.",
        vitalityAdd: 11,
        vitalityMult: 1.001f,
        armorAdd: 1,
        armorMult: 1.001f,
        strengthAdd: 0,
        strengthMult: 1f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 3,
        manaMult: 1f
        
    ) {
        
    }

}