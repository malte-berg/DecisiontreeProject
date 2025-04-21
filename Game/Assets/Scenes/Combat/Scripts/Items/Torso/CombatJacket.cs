using System.Collections.Generic;
using UnityEngine;

public class CombatJacket : Torso{

    public CombatJacket() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/combatJacket_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/combatJacket1"), Resources.Load<Sprite>("Sprites/Items/combatJacket2")},
        name: "Combat Jacket",
        value: 180,
        description: "A preppers dream, made to carry first aid and ammunition.",
        vitalityAdd: 60,
        vitalityMult: 1.015f,
        armorAdd: 6,
        armorMult: 1.006f,
        strengthAdd: 5,
        strengthMult: 1.001f,
        magicAdd: 1,
        magicMult: 1.001f,
        manaAdd: 4,
        manaMult: 1f
        
    ) {
        
    }

}