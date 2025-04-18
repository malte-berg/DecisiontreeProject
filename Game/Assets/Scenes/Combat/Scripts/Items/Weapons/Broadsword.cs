using System.Collections.Generic;
using UnityEngine;

public class Broadsword : Weapon{
    public Broadsword() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/broadSword_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/sword1"), Resources.Load<Sprite>("Sprites/Items/sword2")},
        name: "Broadsword",
        value: 70,
        description: "Simply created to defend and defeat the enemy.",
        vitalityAdd: 3,
        vitalityMult: 1.001f,
        armorAdd: 0,
        armorMult: 1f,
        strengthAdd: 17,
        strengthMult: 1.008f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}