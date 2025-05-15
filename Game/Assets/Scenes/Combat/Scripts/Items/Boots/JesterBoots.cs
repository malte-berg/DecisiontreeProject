using UnityEngine;

public class JesterBoots : Boots{

    public JesterBoots() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/jesterShoes_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/jesterShoes"),
        name: "Jester Boots",
        value: 80,
        description: "Not as silly as they look.",
        vitalityAdd: 30,
        vitalityMult: 1f,
        armorAdd: 4,
        armorMult: 1f,
        strengthAdd: 1,
        strengthMult: 1.002f,
        magicAdd: 6,
        magicMult: 1.01f,
        manaAdd: 15,
        manaMult: 1f
        
    ) {
        
    }

}