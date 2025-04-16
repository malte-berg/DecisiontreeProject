using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon{

    public Knife() : base(

        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/knife1"), Resources.Load<Sprite>("Sprites/Items/knife2")},
        name: "Knife",
        value: 15,
        description: "A slightly blunt kitchen knife that has been used many times for multiple things.",
        vitalityAdd: 0,
        vitalityMult: 1,
        armorAdd: 0,
        armorMult: 1,
        strengthAdd: 2,
        strengthMult: 1.005f,
        magicAdd: 0,
        magicMult: 1,
        manaAdd: 0,
        manaMult: 1

    ) {
        
    }

}