
using UnityEngine;

public class GladiatorHelmet : Head{
    public GladiatorHelmet() : base(
        
        icon: Resources.Load<Sprite>("Sprites/Icons/gladiatorHelmet_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/gladiatorHelmet"),
        name: "Warrior Helmet",
        value: 2,
        description: "SPARTAA!!",
        vitalityAdd: 1,
        vitalityMult: 1f,
        armorAdd: 7,
        armorMult: 1f,
        strengthAdd: -2,
        strengthMult: 0.9f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}