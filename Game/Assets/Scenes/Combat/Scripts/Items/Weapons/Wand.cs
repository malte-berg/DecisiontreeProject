using System.Collections.Generic;
using UnityEngine;

public class Wand : Weapon{

    public Wand() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/Wand_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/wand1"), Resources.Load<Sprite>("Sprites/Items/wand2")},
        name: "Wand",
        value: 25,
        description: "Just a stick found in the woods, or is it?",
        vitalityAdd: 0,
        vitalityMult: 1,
        armorAdd: 0,
        armorMult: 1,
        strengthAdd: 0,
        strengthMult: 1.005f,
        magicAdd: 8,
        magicMult: 1,
        manaAdd: 15,
        manaMult: 1

    ) {
        
    }

}