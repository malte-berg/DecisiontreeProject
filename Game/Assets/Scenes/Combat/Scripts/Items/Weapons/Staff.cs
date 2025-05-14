using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon{

    public Staff() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/Staff_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/staff1"), Resources.Load<Sprite>("Sprites/Items/staff2")},
        name: "Magic Staff",
        value: 180,
        description: "Rather powerfull when wielded by the right wizard",
        vitalityAdd: 8,
        vitalityMult: 1.005f,
        armorAdd: 1,
        armorMult: 1f,
        strengthAdd: 3,
        strengthMult: 1.01f,
        magicAdd: 12,
        magicMult: 1.03f,
        manaAdd: 25,
        manaMult: 1f
        
    ) {
        
    }

}