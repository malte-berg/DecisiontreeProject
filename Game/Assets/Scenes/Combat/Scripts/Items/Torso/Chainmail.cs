using System.Collections.Generic;
using UnityEngine;

public class Chainmail : Torso{

    public Chainmail() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/chainmail_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/chainmail1"), Resources.Load<Sprite>("Sprites/Items/chainmail2")},
        name: "Chainmail",
        value: 60,
        description: "A slightly heavy piece of armor that works wonders against slashes.",
        vitalityAdd: 20,
        vitalityMult: 1.005f,
        armorAdd: 4,
        armorMult: 1.004f,
        strengthAdd: 1,
        strengthMult: 1f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 2,
        manaMult: 1f
        
    ) {
        
    }

}