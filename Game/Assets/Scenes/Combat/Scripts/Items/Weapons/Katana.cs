using System.Collections.Generic;
using UnityEngine;

public class Katana : Weapon{

    public Katana() : base(

        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/katana1"), Resources.Load<Sprite>("Sprites/Items/katana2")},
        name: "Katana",
        value: 110,
        description: "Surviving the nuclear blast the way of the Samurai persists.",
        vitalityAdd: 8,
        vitalityMult: 1.005f,
        armorAdd: 1,
        armorMult: 1.001f,
        strengthAdd: 22,
        strengthMult: 1.01f,
        magicAdd: 1,
        magicMult: 1f,
        manaAdd: 10,
        manaMult: 1f
        
    ) {
        
    }

}