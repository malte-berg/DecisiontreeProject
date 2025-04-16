using System.Collections.Generic;
using UnityEngine;

public class MilitaryJacket : Torso{

    public MilitaryJacket() : base(

        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/militaryJacket1"), Resources.Load<Sprite>("Sprites/Items/militaryJacket2")}, 
        name: "Military Jacket",
        value: 320,
        description: "Gathered from the armies of the dead.",
        vitalityAdd: 90,
        vitalityMult: 1.02f,
        armorAdd: 11,
        armorMult: 1.014f,
        strengthAdd: 9,
        strengthMult: 1.002f,
        magicAdd: 4,
        magicMult: 1.002f,
        manaAdd: 5,
        manaMult: 1.001f
        
    ) {
        
    }

}