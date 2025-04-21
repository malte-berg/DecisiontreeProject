using System.Collections.Generic;
using UnityEngine;

public class Jacket : Torso{

    public Jacket() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/Jacket_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/jacket1"), Resources.Load<Sprite>("Sprites/Items/jacket2")},
        name: "Jacket",
        value: 20,
        description: "A wasteland jacket that either was ripped from a corpse or stolen from a victim.",
        vitalityAdd: 20,
        vitalityMult: 1f,
        armorAdd: 0,
        armorMult: 1.001f,
        strengthAdd: 2,
        strengthMult: 1f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}