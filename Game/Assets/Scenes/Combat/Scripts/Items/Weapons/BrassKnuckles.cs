using System.Collections.Generic;
using UnityEngine;

public class BrassKnuckles : Weapon{

    public BrassKnuckles() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/brassKnuckles_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/brassKnuckles")},
        name: "Brass Knuckles",
        value: 40,
        description: "The hard cold brass shall be felt in your enemies face.",
        vitalityAdd: 0,
        vitalityMult: 1.002f,
        armorAdd: 0,
        armorMult: 1.001f,
        strengthAdd: 6,
        strengthMult: 1.001f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}